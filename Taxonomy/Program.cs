using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using System.Xml;
using Microsoft.SharePoint.Utilities;
using System.IO;

namespace SSOMChanged
{
    class Program
    {

        private static TermStore _termStore;
        private static TaxonomyGroup _taxonomyGroup;
        private static TermSetInfo _termsetInfo;
        private static List<TermInfo> _termInfos = null;
        private static string valueSource = "test.xml";
        public static TermStore TermStore
        {
            get
            {
                return _termStore;
            }
            set
            {
                _termStore = value;
            }
        }

        public static TaxonomyGroup TaxonomyGroup
        {
            get
            {
                return _taxonomyGroup;
            }
            set
            {
                _taxonomyGroup = value;
            }
        }

        public static TermSetInfo TermsetInfo
        {
            get
            {
                return _termsetInfo;
            }
            set
            {
                _termsetInfo = value;
            }
        }

        public static List<TermInfo> TermInfos
        {
            get
            {
                return _termInfos;
            }
            set
            {
                _termInfos = value;
            }
        }

        private static void GenerateDefaultTaxonomyTreeFromXMLFile(SPSite site)
        {
            using (site)
            {
                TaxonomySession taxonomySession = new TaxonomySession(site);
                TermStore termStore = taxonomySession.DefaultSiteCollectionTermStore;

                if (termStore != null)
                {
                    TermStore = termStore;

                    var web = site.RootWeb;

                    XmlDocument document = new XmlDocument();
                    SPFile file = web.GetFile(String.Format("{0}/{1}", web.Url, valueSource));
                    using (Stream fileStream = file.OpenBinaryStream())
                    {
                        document.Load(fileStream);
                        fileStream.Close();
                    }

                    GetNodes((XmlNode)document.DocumentElement);
                    try
                    {
                        CreateTaxonomyTree();
                        TermStore.CommitAll();
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        private static void GetNodes(XmlNode root)
        {
            if (root is XmlElement)
            {
                CreateTaxonomyElement(root);
                if (root.HasChildNodes)
                {
                    foreach (XmlNode childNode in root.ChildNodes)
                    {
                        GetNodes(childNode);

                    }
                    if (TermInfos != null && root.Name.Equals("term"))
                    {
                        var lastTerm = TermInfos.Last();
                        if (String.IsNullOrEmpty(lastTerm.TermFormat))
                        {
                            TermInfos.RemoveAt(TermInfos.Count - 1);
                            TermInfos.ElementAt(TermInfos.Count - 1).ChildTermInfos.Add(lastTerm);
                        }
                    }
                }
                else
                {
                    return;
                }

                return;
            }

        }

        private static void CreateTaxonomyElement(XmlNode node)
        {
            switch (node.Name)
            {
                case "taxonomyGroup":
                    TaxonomyGroup = new TaxonomyGroup();
                    break;

                case "taxonomyTermsets":
                    break;

                case "taxonomyTermset":
                    TermsetInfo = new TermSetInfo();
                    break;

                case "terms":
                    if (TermInfos == null)
                    {
                        TermInfos = new List<TermInfo>();
                    }
                    break;

                case "term":
                    var termInfo = new TermInfo();
                    termInfo.TermId = Guid.NewGuid();
                    TermInfos.Add(termInfo);
                    break;

                case "name":
                    NameParent(node.ParentNode.Name, node.InnerXml);
                    break;

                case "format":
                    var lastTerm = TermInfos.Last();
                    lastTerm.TermFormat = node.InnerXml;
                    break;

                case "url":
                    var term = TermInfos.Last();
                    term.TermHref = node.InnerXml;
                    break;

                case "order":
                    var finalTerm = TermInfos.Last();
                    finalTerm.TermOrder = Convert.ToInt32(Int32.Parse(node.InnerXml));
                    break;

                default:
                    break;
            }
        }

        private static void CreateTaxonomyTree()
        {
            Group group = null;
            TermSet termset = null;

            if (!(CheckIfGroupExists()))
            {
                try
                {
                    group = CreateGroup();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                group = TermStore.Groups.Where(s => s.Name == TaxonomyGroup.Name).First();
            }

            if (group != null)
            {
                if (!(CheckIfTermSetExists(group)))
                {
                    try
                    {
                        termset = CreateTermset(group);
                        CreateTerms(termset);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    throw new Exception(String.Format("Termset {0} already exists!", TermsetInfo.Name));
                }
            }
        }

        private static bool CheckIfGroupExists()
        {
            bool exist = false;

            var groups = TermStore.Groups.Where(s => s.Name == TaxonomyGroup.Name);

            if (groups.Count() != 0)
            {
                exist = true;
            }
            return exist;
        }

        private static bool CheckIfTermSetExists(Group group)
        {
            bool exist = false;

            var termsets = group.TermSets.Where(s => s.Name == TermsetInfo.Name);

            if (termsets.Count() != 0)
            {
                exist = true;
            }
            return exist;
        }

        private static Group CreateGroup()
        {
            Group group = null;

            group = TermStore.CreateGroup(TaxonomyGroup.Name, TaxonomyGroup.Id);

            if (group != null)
            {
                return group;
            }
            else
            {
                throw new Exception(String.Format("Group {0} could not be created!", TaxonomyGroup.Name));
            }
        }

        private static TermSet CreateTermset(Group group)
        {
            TermSet termset = null;
            var termSetLcid = 1033;

            termset = group.CreateTermSet(TermsetInfo.Name, TermsetInfo.TermSetId, termSetLcid);

            if (termset != null)
            {
                return termset;
            }
            else
            {
                throw new Exception(String.Format("Termset {0} could not be created!", TermsetInfo.Name));
            }
        }

        private static void CreateTerms(TermSet termset)
        {
            var lcid = 1033;
            foreach (var term in TermInfos)
            {
                var newTerm = termset.CreateTerm(term.TermName, lcid, Guid.NewGuid());
                newTerm.SetCustomProperty("Format", term.TermFormat);

                CreateSubTerms(term, newTerm);

            }
            string[] order = SetOrder(TermInfos);
            termset.CustomSortOrder = String.Join(":", order);
        }

        private static void CreateSubTerms(TermInfo termInfo, Term term)
        {
            var lcid = 1033;
            if (termInfo.ChildTermInfos.Count != 0)
            {
                foreach (var childTerm in termInfo.ChildTermInfos)
                {
                    var newTerm = term.CreateTerm(childTerm.TermName, lcid, Guid.NewGuid());
                    newTerm.SetCustomProperty("Url", childTerm.TermHref);

                    CreateSubTerms(childTerm, newTerm);

                }
                string[] order = SetOrder(termInfo.ChildTermInfos);
                term.CustomSortOrder = String.Join(":", order);
            }
            else
            {
                return;
            }
        }

        private static string[] SetOrder(List<TermInfo> termInfos)
        {
            Dictionary<int, string> termsOrderId = new Dictionary<int, string>();

            foreach (var termInfo in termInfos)
            {
                termsOrderId.Add(termInfo.TermOrder, termInfo.TermId.ToString());
            }
            string[] order = new string[termsOrderId.Count];
            for (int i = 1; i <= termsOrderId.Count; i++)
            {
                order[i - 1] = termsOrderId[i];
            }

            return order;
        }

        private static void NameParent(string parentName, string name)
        {
            switch (parentName)
            {
                case "taxonomyGroup":
                    try
                    {
                        TaxonomyGroup.Name = name;
                        TaxonomyGroup.Id = Guid.NewGuid();
                    }
                    catch (Exception ex)
                    {
                    }
                    break;

                case "taxonomyTermset":
                    try
                    {
                        TermsetInfo.Name = name;
                        TermsetInfo.TermSetId = Guid.NewGuid();
                        TaxonomyGroup.TermSet = TermsetInfo;
                    }
                    catch (Exception ex)
                    {
                    }
                    break;

                case "term":
                    var termInfo = TermInfos.Last();
                    termInfo.TermName = name;
                    break;

                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            var siteUrl = "";

            var site = new SPSite(siteUrl);

            GenerateDefaultTaxonomyTreeFromXMLFile(site);
        }
    }
}
