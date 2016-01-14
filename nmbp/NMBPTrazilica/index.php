<script>
		var definition = {smile:{title:"Smile",codes:[":)",":=)",":-)"]},"sad-smile":{title:"Sad Smile",codes:[":(",":=(",":-("]},"big-smile":{title:"Big Smile",codes:[":D",":=D",":-D",":d",":=d",":-d"]},cool:{title:"Cool",codes:["8)","8=)","8-)","B)","B=)","B-)","(cool)"]},wink:{title:"Wink",codes:[":o",":=o",":-o",":O",":=O",":-O"]},crying:{title:"Crying",codes:[";(",";-(",";=("]},sweating:{title:"Sweating",codes:["(sweat)","(:|"]},speechless:{title:"Speechless",codes:[":|",":=|",":-|"]},kiss:{title:"Kiss",codes:[":*",":=*",":-*"]},"tongue-out":{title:"Tongue Out",codes:[":P",":=P",":-P",":p",":=p",":-p"]},blush:{title:"Blush",codes:["(blush)",":$",":-$",":=$",':">']},wondering:{title:"Wondering",codes:[":^)"]},sleepy:{title:"Sleepy",codes:["|-)","I-)","I=)","(snooze)"]},dull:{title:"Dull",codes:["|(","|-(","|=("]},"in-love":{title:"In love",codes:["(inlove)"]},"evil-grin":{title:"Evil grin",codes:["]:)",">:)","(grin)"]},talking:{title:"Talking",codes:["(talk)"]},yawn:{title:"Yawn",codes:["(yawn)","|-()"]},puke:{title:"Puke",codes:["(puke)",":&",":-&",":=&"]},"doh!":{title:"Doh!",codes:["(doh)"]},angry:{title:"Angry",codes:[":@",":-@",":=@","x(","x-(","x=(","X(","X-(","X=("]},"it-wasnt-me":{title:"It wasn't me",codes:["(wasntme)"]},party:{title:"Party!!!",codes:["(party)"]},worried:{title:"Worried",codes:[":S",":-S",":=S",":s",":-s",":=s"]},mmm:{title:"Mmm...",codes:["(mm)"]},nerd:{title:"Nerd",codes:["8-|","B-|","8|","B|","8=|","B=|","(nerd)"]},"lips-sealed":{title:"Lips Sealed",codes:[":x",":-x",":X",":-X",":#",":-#",":=x",":=X",":=#"]},hi:{title:"Hi",codes:["(hi)"]},call:{title:"Call",codes:["(call)"]},devil:{title:"Devil",codes:["(devil)"]},angel:{title:"Angel",codes:["(angel)"]},envy:{title:"Envy",codes:["(envy)"]},wait:{title:"Wait",codes:["(wait)"]},bear:{title:"Bear",codes:["(bear)","(hug)"]},"make-up":{title:"Make-up",codes:["(makeup)","(kate)"]},"covered-laugh":{title:"Covered Laugh",codes:["(giggle)","(chuckle)"]},"clapping-hands":{title:"Clapping Hands",codes:["(clap)"]},thinking:{title:"Thinking",codes:["(think)",":?",":-?",":=?"]},bow:{title:"Bow",codes:["(bow)"]},rofl:{title:"Rolling on the floor laughing",codes:["(rofl)"]},whew:{title:"Whew",codes:["(whew)"]},happy:{title:"Happy",codes:["(happy)"]},smirking:{title:"Smirking",codes:["(smirk)"]},nodding:{title:"Nodding",codes:["(nod)"]},shaking:{title:"Shaking",codes:["(shake)"]},punch:{title:"Punch",codes:["(punch)"]},emo:{title:"Emo",codes:["(emo)"]},yes:{title:"Yes",codes:["(y)","(Y)","(ok)"]},no:{title:"No",codes:["(n)","(N)"]},handshake:{title:"Shaking Hands",codes:["(handshake)"]},skype:{title:"Skype",codes:["(skype)","(ss)"]},heart:{title:"Heart",codes:["(h)","<3","(H)","(l)","(L)"]},"broken-heart":{title:"Broken heart",codes:["(u)","(U)"]},mail:{title:"Mail",codes:["(e)","(m)"]},flower:{title:"Flower",codes:["(f)","(F)"]},rain:{title:"Rain",codes:["(rain)","(london)","(st)"]},sun:{title:"Sun",codes:["(sun)"]},time:{title:"Time",codes:["(o)","(O)","(time)"]},music:{title:"Music",codes:["(music)"]},movie:{title:"Movie",codes:["(~)","(film)","(movie)"]},phone:{title:"Phone",codes:["(mp)","(ph)"]},coffee:{title:"Coffee",codes:["(coffee)"]},pizza:{title:"Pizza",codes:["(pizza)","(pi)"]},cash:{title:"Cash",codes:["(cash)","(mo)","($)"]},muscle:{title:"Muscle",codes:["(muscle)","(flex)"]},cake:{title:"Cake",codes:["(^)","(cake)"]},beer:{title:"Beer",codes:["(beer)"]},drink:{title:"Drink",codes:["(d)","(D)"]},dance:{title:"Dance",codes:["(dance)","\\o/","\\:D/","\\:d/"]},ninja:{title:"Ninja",codes:["(ninja)"]},star:{title:"Star",codes:["(*)"]},mooning:{title:"Mooning",codes:["(mooning)"]},finger:{title:"Finger",codes:["(finger)"]},bandit:{title:"Bandit",codes:["(bandit)"]},drunk:{title:"Drunk",codes:["(drunk)"]},smoking:{title:"Smoking",codes:["(smoking)","(smoke)","(ci)"]},toivo:{title:"Toivo",codes:["(toivo)"]},rock:{title:"Rock",codes:["(rock)"]},headbang:{title:"Headbang",codes:["(headbang)","(banghead)"]},bug:{title:"Bug",codes:["(bug)"]},fubar:{title:"Fubar",codes:["(fubar)"]},poolparty:{title:"Poolparty",codes:["(poolparty)"]},swearing:{title:"Swearing",codes:["(swear)"]},tmi:{title:"TMI",codes:["(tmi)"]},heidy:{title:"Heidy",codes:["(heidy)"]},myspace:{title:"MySpace",codes:["(MySpace)"]},malthe:{title:"Malthe",codes:["(malthe)"]},tauri:{title:"Tauri",codes:["(tauri)"]},priidu:{title:"Priidu",codes:["(priidu)"]}};
		var snowmax=70
		var snowcolor=new Array("#aaaacc","#ddddFF","#ccccDD")
		var snowtype=new Array("Arial Black","Arial Narrow","Times","Comic Sans MS")
		var snowletter="*"
		var sinkspeed=0.5
		var snowmaxsize=30
		var snowminsize=10
		var snowingzone=1

		var snow=new Array()
		var marginbottom
		var marginright
		var timer
		var i_snow=0
		var x_mv=new Array();
		var crds=new Array();
		var lftrght=new Array();
		var browserinfos=navigator.userAgent 
		var ie5=document.all&&document.getElementById&&!browserinfos.match(/Opera/)
		var ns6=document.getElementById&&!document.all
		var opera=browserinfos.match(/Opera/)  
		var browserok=ie5||ns6||opera

		function randommaker(range) {		
			rand=Math.floor(range*Math.random())
			return rand
		}

		function initsnow() {
			if (ie5 || opera) {
				marginbottom = document.body.clientHeight
				marginright = document.body.clientWidth
			}
			else if (ns6) {
				marginbottom = window.innerHeight
				marginright = window.innerWidth
			}
			var snowsizerange=snowmaxsize-snowminsize
			for (i=0;i<=snowmax;i++) {
				crds[i] = 0;                      
				lftrght[i] = Math.random()*15;         
				x_mv[i] = 0.03 + Math.random()/10;
				snow[i]=document.getElementById("s"+i)
				snow[i].style.fontFamily=snowtype[randommaker(snowtype.length)]
				snow[i].size=randommaker(snowsizerange)+snowminsize
				snow[i].style.fontSize=snow[i].size
				snow[i].style.color=snowcolor[randommaker(snowcolor.length)]
				snow[i].sink=sinkspeed*snow[i].size/5
				if (snowingzone==1) {snow[i].posx=randommaker(marginright-snow[i].size)}
				if (snowingzone==2) {snow[i].posx=randommaker(marginright/2-snow[i].size)}
				if (snowingzone==3) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/4}
				if (snowingzone==4) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/2}
				snow[i].posy=randommaker(2*marginbottom-marginbottom-2*snow[i].size)
				snow[i].style.left=snow[i].posx
				snow[i].style.top=snow[i].posy
			}
			movesnow()
		}

		function movesnow() {
			for (i=0;i<=snowmax;i++) {
				crds[i] += x_mv[i];
				snow[i].posy+=snow[i].sink
				snow[i].style.left=snow[i].posx+lftrght[i]*Math.sin(crds[i]);
				snow[i].style.top=snow[i].posy
				
				if (snow[i].posy>=marginbottom-2*snow[i].size || parseInt(snow[i].style.left)>(marginright-3*lftrght[i])){
					if (snowingzone==1) {snow[i].posx=randommaker(marginright-snow[i].size)}
					if (snowingzone==2) {snow[i].posx=randommaker(marginright/2-snow[i].size)}
					if (snowingzone==3) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/4}
					if (snowingzone==4) {snow[i].posx=randommaker(marginright/2-snow[i].size)+marginright/2}
					snow[i].posy=0
				}
			}
			var timer=setTimeout("movesnow()",50)
		}

		for (i=0;i<=snowmax;i++) {
			document.write("<span id='s"+i+"' style='position:absolute;top:-"+snowmaxsize+"'>"+snowletter+"</span>")
		}
		if (browserok) {
			window.onload=initsnow
		}
		</script>
		
<?php 

include_once 'db.php';
include_once 'common.php';
include('includes/header.php');
$action = "";
$sqlQuery = "";
$sve = "";
extract($_POST);
extract($_GET); 
?>

  <div class="form-wrap">
      <form class="form" action="index.php" method="post">
        <input type="hidden" name="action" value="pretrazivanje"> 
        <h2 class="form-heading"></h2>
        <label class="sr-only" for="naziv"><font color = "#FFFFFF">Naziv</font></label>
        <input type="text" class="form-control" id="naziv" name="naziv" placeholder="Naziv filma za pretragu" autofocus>
        <div class="form-group">
            <label class="radio-inline">
              <input type="radio" id="and" name="logickiOperator" value="and" checked><font color = "#FFFFFF">AND</font>
            </label>
            <label class="radio-inline">
              <input type="radio" id="or" name="logickiOperator" value="or"><font color = "#FFFFFF">OR</font>
            </label>
        </div>
        <div class="form-group">
            <select name="pretrazi">
              <option value="ExactStringMatching"><font color = "#FFFFFF">Exact string matching</font></option>
              <option value="UseDictionaries"><font color = "#FFFFFF">Use dictionaries</font></option>
              <option value="FuzzyStringMatching"><font color = "#FFFFFF">Fuzzy string matching</font></option>
            </select>
        </div>
        <button class="btn btn-lg btn-primary btn-block" type="submit"><font color = "#FFFFFF">Search</font></button>
      </form>
   </div>   

  <div class="query-wrap">
    <div class="sqlQuery">
      
         <?php 
            if ( $action == "pretrazivanje") // ako je odabrano pretraživanje
            {
                
                
                $tmp = "";
                $konacni = "";
                $naziv1 =$naziv;
                if (substr($naziv, 0, 1) != '"'){
                  $words = explode(' ', $naziv);
                  foreach($words as $w){
                    $konacni .= $w.' && ';
                  }
                  $konacni = substr($konacni, 0, strlen($konacni) -3);
                  #echo "Ovo je kad imam samo rijeci ".$konacni;
                }
                else{
                  $naziv = str_replace("\" \"", '*', substr($naziv, 1, strlen($naziv)));
                  $naziv=str_replace("\" ", '%', $naziv);  
                  if (strpos($naziv, '%') == false){
                    $tmp = explode('*', $naziv);
                    foreach($tmp as $t){
                      $t = str_replace(' ', ' & ', $t);
                      $konacni .= '('.$t.') && ';
                    }
                    $konacni = substr($konacni, 0, strlen($konacni) -3);
                    #echo "Ovo je samo kad imam izraze i nazive  ".$konacni;
                  }
                  else{
                    $naziv = str_replace('"','',$naziv);
                    $tmp  = explode('%', $naziv);
                    $tmp[0] = explode('*', $tmp[0]);
                    $tmp[1] = explode(' ', $tmp[1]);
                    foreach($tmp[0] as $l){
                      $l = str_replace(' ',' & ',$l);
                      $konacni .= '('.$l.') && ';
                    }
                    foreach ($tmp[1] as $t){
                      $konacni .= $t.' & ';
                    }
                    $konacni = substr($konacni, 0, strlen($konacni) - 3);
                    #echo "Ovo je kad imam kombinaciju $konacni";
                 }
                }

                if($_POST['logickiOperator'] == 'or'){
                  $up = str_replace('&&', '|',str_replace(array('(', ')'), '', str_replace(' & ', ' ', $konacni)));
                }
                else{  
                  $up = str_replace('&&', '&',str_replace(array('(', ')'), '', str_replace(' & ', ' ', $konacni)));
                }
                $up = str_replace('"','',$up);
                
                $upit = "INSERT INTO movies.upiti(upit, datum_unosa, vrijeme_unosa) VALUES('$up', now(), now())";  
                $result = pg_exec($db, $upit);
              
                if($_POST['logickiOperator'] == 'or'){
                    $konacni = str_replace('&&', ' | ', $konacni);
                    if(strcmp($_POST['pretrazi'],"ExactStringMatching") == 0){
                        $query = "SELECT ID, <br>
                                         ts_headline( naziv, to_tsquery('$konacni')), <br>
                                         naziv, <br>
                                         redatelj, <br>
                                         zanr, <br>
                                         vrijeme_trajanja, <br>
                                         glavni_glumac, <br>
                                         ts_rank(naziv_ts, to_tsquery ('english','$konacni')) rank <br>
                                         FROM movies.filmovi <br>
                                         WHERE naziv LIKE ";

                        $zapis="'%";
                        $konacni=str_replace(' ','', $konacni);
                        $cut=explode('|', $konacni);
                        foreach($cut as $c){
                          if (substr($c, 0, 1) =='('){
                            $zapis.=str_replace('&',' ',str_replace(array('(',')'),'',$c))."%' <br> OR naziv LIKE '%";
                          }
                          else{
                            $zapis.=str_replace(' ','',$c)."%' <br> OR naziv LIKE '%";
                          }
                        }
                        $zapis = substr($zapis,0, -17);
                        $query.=$zapis."ORDER BY rank DESC";
                        echo "<h4><font color = \"#FFFFFF\">Exact string matching: <br><br></font></h4>".$query."";
                    }
                    elseif(strcmp($_POST['pretrazi'],"UseDictionaries") == 0){
                        $query = "SELECT ID, <br>
                                         ts_headline( naziv, to_tsquery('$konacni')), <br>
                                         naziv, <br>
                                         redatelj, <br>
                                         zanr, <br>
                                         vrijeme_trajanja, <br>
                                         glavni_glumac, <br>
                                         ts_rank(naziv_ts, to_tsquery ('english','$konacni')) rank <br>
                                         FROM movies.filmovi <br>
                                         WHERE ";
                        $zapis="";
                        $konacni=str_replace(' ','', $konacni);
                        $cut=explode('|', $konacni);
                        foreach($cut as $c){
                          if (substr($c, 0, 1) =='('){
                            $zapis.=" naziv_ts @@ to_tsquery('english', '".str_replace('&', ' & ', str_replace(array('(',')'),'',$c))." ' ) <br> OR ";
                          }
                          else{
                            $zapis.=" naziv_ts @@ to_tsquery('english', '".str_replace(' ','',$c)." ' ) <br> OR ";
                          }
                        }
                        $zapis = substr($zapis,0,-4);
                        $query.=$zapis."ORDER BY rank DESC"; 
                        echo "<h4><font color = \"#FFFFFF\">Using dictionaries: <br><br></font></h4>".$query."";
                    }
                    else{
                        $query = "SELECT ID, <br>
                                         ts_headline( naziv, to_tsquery('$konacni')), <br>
                                         naziv, <br>
                                         redatelj, <br>
                                         zanr, <br>
                                         vrijeme_trajanja, <br>
                                         glavni_glumac, <br>
                                         ts_rank(naziv_ts, to_tsquery ('english','$konacni')) rank <br>
                                         FROM movies.filmovi <br>
                                         WHERE naziv % ";

                        $zapis="'";
                        $konacni=str_replace(' ','', $konacni);
                        $cut=explode('|', $konacni);
                        foreach($cut as $c){
                          if (substr($c, 0, 1) =='('){
                            $zapis.=str_replace('&',' ',str_replace(array('(',')'),'',$c))."' <br> OR naziv % '";
                          }
                          else{
                            $zapis.=str_replace(' ','',$c)."' <br> OR naziv % '";
                          } 
                        }  
                        $zapis = substr($zapis,0, -13);
                        $query.=$zapis."ORDER BY rank DESC";
                        echo "<h4><font color = \"#FFFFFF\">Fuzzy string matching: <br><br></font></h4>".$query."";
                    }
                }else{
                    $kon = str_replace('&&', ' | ', $konacni);
                    $konacni = str_replace('&&', ' & ', $konacni);
                    if(strcmp($_POST['pretrazi'],"ExactStringMatching") == 0){
                        $query = "SELECT ID, <br>
                                         ts_headline( naziv, to_tsquery('$konacni')), <br>
                                         naziv, <br>
                                         redatelj, <br>
                                         zanr, <br>
                                         vrijeme_trajanja, <br>
                                         glavni_glumac, <br>
                                         ts_rank(naziv_ts, to_tsquery ('english','$konacni')) rank <br>
                                         FROM movies.filmovi <br>
                                         WHERE naziv LIKE "; 
                        $zapis="'%";
                        $kon=str_replace(' ','', $kon);
                        $cut=explode('|', $kon);
                        foreach($cut as $c){
                          if (substr($c, 0, 1) =='('){
                            $zapis.=str_replace('&',' ',str_replace(array('(',')'),'',$c))."%' <br> AND naziv LIKE '%";
                          }
                          else{
                            $zapis.=str_replace(' ','',$c)."%' <br> AND naziv LIKE '%";
                          }
                        } 
                        $zapis = substr($zapis,0, -17);
                        $query.=$zapis."ORDER BY rank DESC";
                        echo "<h4><font color = \"#FFFFFF\">Exact string matching: <br><br></font></h4>".$query."";
                    }
                    elseif(strcmp($_POST['pretrazi'],"UseDictionaries") == 0){
                        $query = "SELECT ID, <br>
                                         ts_headline( naziv, to_tsquery('$konacni')), <br>
                                         naziv, <br>
                                         redatelj, <br>
                                         zanr, <br>
                                         vrijeme_trajanja, <br>
                                         glavni_glumac, <br>
                                         ts_rank(naziv_ts, to_tsquery ('english','$konacni')) rank <br>
                                         FROM movies.filmovi <br>
                                         WHERE ";
                        $zapis="";
                        $kon=str_replace(' ','', $kon);
                        $cut=explode('|', $kon);
                        foreach($cut as $c){
                          if (substr($c, 0, 1) =='('){
                            $zapis.=" naziv_ts @@ to_tsquery('english', '".str_replace('&', ' & ', str_replace(array('(',')'),'',$c))." ' ) <br> AND ";
                          }
                          else{
                            $zapis.=" naziv_ts @@ to_tsquery('english', '".str_replace(' ','',$c)." ' ) <br> AND ";
                          }
                        }
                        $zapis = substr($zapis,0,-4);
                        $query.=$zapis."ORDER BY rank DESC"; 
                        echo "<h4><font color = \"#FFFFFF\">Using dictionaries: <br><br></font></h4>".$query."";
                    }
                    elseif(strcmp($_POST['pretrazi'],"FuzzyStringMatching") == 0){
                        $query = "SELECT ID, <br>
                                         ts_headline( naziv, to_tsquery('$konacni')), <br>
                                         naziv, <br>
                                         redatelj, <br>
                                         zanr, <br>
                                         vrijeme_trajanja, <br>
                                         glavni_glumac, <br>
                                         ts_rank(naziv_ts, to_tsquery ('english','$konacni')) rank <br>
                                         FROM movies.filmovi <br>
                                         WHERE naziv % ";
                                         
                        $zapis="'";
                        $kon=str_replace(' ','', $kon);
                        $cut=explode('|', $kon);
                        foreach($cut as $c){
                          if (substr($c, 0, 1) =='('){
                            $zapis.=str_replace('&',' ',str_replace(array('(',')'),'',$c))."' <br> AND naziv % '";
                          }
                          else{
                            $zapis.=str_replace(' ','',$c)."' <br> AND naziv % '";
                          } 
                        } 
                        $zapis = substr($zapis,0, -13);
                        $query.=$zapis."ORDER BY rank DESC";
                        echo "<h4><font color = \"#FFFFFF\">Fuzzy string matching: <br><br></font></h4>".$query."";
                    }}   
                   $query = str_replace("<b>",'',$query);
                   $query = str_replace("<br>","",$query);
                } 
                 ?>
        </div>
   </div>

<script>  
        $(document).ready(function() {
          $('#rezultati').children("div").click(function() {
             $(this).find("p").animate({
                height: 'toggle'
                }, 200
            );
         });
       });
</script>


<!--ispis rezultata -->
 <?php
       $Query = "";
       $pomNiz = "";
       $pomOpis= "";
       
       if ($query != "")
       {
               $Query=pg_query($db, $query);
               echo "<br>Number of documents retrieved:  " . pg_numrows($Query) ." <br> ";
              
               if (pg_numrows($Query)>0)
               {
                 $sve = pg_fetch_all($Query); 
                
                 echo "<div id='rezultati'>";
                 foreach ($sve as $res)
                 {
                      $pomNiz =$res['ts_headline']."[ ".$res['rank'] ."]"; 
                      $pomOpis = $res['naziv']. ", " . $res ['redatelj']. ", " . $res ['glavni_glumac']. ", " . $res ['zanr'];
   
                      echo "<div><a style= \"background-color: black; color: blue; padding: 5px; width: 100px; cursor:pointer;\"><br>$pomNiz </br></a>";  
                      echo "<p style =\"display: none;\">$pomOpis</p></div>";
                  }
                  echo "</div>";
               } 
       }           
       
 ?>



