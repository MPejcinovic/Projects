import sys
import re

pomocna = []
temp = []
final = []
premise = []
lijeva_strana = []
clauses = []
clauses1 = []
skupPotpore = []
zakljucak = []
visited = []
elem = []
ukupno = []
zastavica = True
ubaci = []
skup = []
rez1 = []
rez2 = []
pr= []
operatori = ['&','|','<->','->']
varijable = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z']


def parsiranje(formula):
	global operatori
	global varijable
	
	form = formula.strip()
	duljina = len(form)
	
	if duljina == 1 and form in varijable:
		return form
	
	depth = 0
	lista = None
	for el in reversed(xrange(len(form))):
		if form[el] == ' ':
			continue
		if form[el] == ')':
			depth = depth +1
		elif form[el] == '(':
			depth = depth -1
		elif depth == 0:
			for x in operatori:
				start = el - len(x) + 1
				if form[start:].startswith(x):
					a = parsiranje(form[0:start])
					b = parsiranje(form[el + 1:])
					lista = [x, a, b]
					break
	if lista:
		return lista
		
	if form[0] == '~':
		return ('~' ,parsiranje(form[1:]))
		
	if form[0] == '(' and form[-1] == ')':
		return parsiranje(form[1:-1])
#################################################################################
#						REZOLUCIJE
#################################################################################

def plResolution(lista, zakljucak,st):
	
	a = False
	
	
	if st == '0':
		a = RezolucijaSkupPotpore(lista, zakljucak)
		if a == True:
			print "Dokazano"
		else:
			print "Nije dokazano"
	
	elif st == '1':
		a = RezolucijaStrategijaPojednostavljenja(lista, zakljucak)
		if a == True:
			print "Dokazano"
		else:
			print "Nije dokazano"
		


def nadjiKlauzule(element):
	global ubaci
	global varijable
	q =''
	for el in element:
		if type(el) is list:
			nadjiKlauzule(el)
		elif el in varijable:
			ubaci.append(q+el)
		elif el == '~':
			q = '~'
		elif type(el) is tuple:
			ubaci.append('~'+el[1])
	
def RijesiKlauzule(element):
	global varijable
	pom = []
	
	for el in element:
		
		if type(el) is tuple:
			pom.append('~'+el[1])
		elif el in varijable:
			pom.append(el)
			print pom
		
		elif type(el) is list:
			pom = RijesiKlauzule(el)
	return pom

	
def izaberi(c1, c2):
	
	izbor = []
	global varijable
	
	for x in c1:
		for y in c2:
			for el in x:
				if el[0] == "~":
					element = el[1]
				else:
					element = '~'+el
				if element in y:
					found = sorted([x,y])
					if found not in izbor:
						izbor.append(found)
					
						
	for i in range(len(c2) - 1):
		for j in range(i+1, len(c2)):
			for el in c2[i]:
				if el[0] == '~':
					element = el[1]
				else:
					element = '~'+el
				if element in c2[j]:
					found = sorted([c2[i],c2[j]])
					if found not in izbor:
						izbor.append(found)
	return izbor
	
	
def plMix(el1,el2):

	global rez2
	global pr
	rezolventa = False
	pom = []
	vrati = []
	uklanjanje = []
	
	
	for elem in el1:
		if elem[0] == '~':
			vrati = elem[1]
		else: 
			vrati = '~' + elem
	
		if vrati in el2:
			index1 = el1.index(elem)
			index2 = el2.index(vrati)
			rezolventa = True
			
			pom = sorted(list(set(el1[0:index1]+el1[index1+1:]+el2[0:index2]+el2[index2+1:])))
			
			if pom not in rez2 and not Valjanost(pom):
				rez2.append(pom)
				if pom not in pr:
					pr.append(pom)
	for i in range(len(rez2)-1):
		a = set(rez2[i])
		for j in range(i+1, len(rez2)):
			b = set(rez2[j])
			
			if b.issubset(a):
				if rez2[i] not in uklanjanje:
					uklanjanje.append(rez2[i])
			
			elif a.issubset(b):
				if rez2[j] not in uklanjanje:
					uklanjanje.append(rez2[j])
	for i in uklanjanje:
		rez2.remove(i)	
	
def plSkupPotpore(el1, el2):
	
	global rez2
	global pr
	rezolventa = False
	pom = []
	uklanjanje = []
	vrati = []

	for elem in el1:
		if elem[0] == '~':
			vrati = elem[1]
		else: 
			vrati = '~'+elem
		
	
		if vrati in el2:
		
			index1 = el1.index(elem)
			index2 = el2.index(vrati)
			rezolventa = True
			pom = sorted(list(set(el1[0:index1]+el1[index1+1:]+el2[0:index2]+el2[index2+1:])))
			
			if pom not in rez2:
				rez2.append(pom)
				if pom not in pr:
					pr.append(pom)
	

	for i in range(len(rez2)-1):
		a = set(rez2[i])
		for j in range(i+1, len(rez2)):
			b = set(rez2[j])
			
			if b.issubset(a):
				if rez2[i] not in uklanjanje:
					uklanjanje.append(rez2[i])
			
			elif a.issubset(b):
				if rez2[j] not in uklanjanje:
					uklanjanje.append(rez2[j])
	for i in uklanjanje:
		rez2.remove(i)
	
	
					


def UkloniOperator(c):
	global varijable
	global operatori
	pom = []
	lijevo = []
	desno = []
	
	for el in c:
		if type(el) is tuple:
			return el
		elif el in varijable:
			return el
		elif el == "~":
			return c
		else:
			lijevo = UkloniOperator(c[1])
			desno= UkloniOperator(c[2])
			pom = [lijevo,desno]
			return pom
	
				
def BezOperatora(c):
	global varijable
	global operatori
	
	pomlista = []
	if type(c) is tuple:
		return c

	for el in c:
		if type(el) is tuple:
			pomlista.append(el)
		elif el in varijable:
			pomlista.append(el)
		elif type(el) is list:
			pomlista = BezOperatora(el)
		else:
			continue
	return pomlista



def Istoimeni(klauzula):
	
	pom = []
	
	if len(klauzula) == 1:
		return klauzula
	for el in klauzula:
		if el not in pom:
			pom.append(el)
	return pom
	
def Valjanost(klauzula):
	
	for el in klauzula:
		if el[0] == '~':
			komplement = el[1]
		else:
			komplement = '~' + el
		for el in klauzula:
			if el == komplement:
				return True
	return False
		
def RezolucijaSkupPotpore(lista,zakljucak):
	global clauses
	global clauses1
	global pr
	global skupPotpore
	global elem
	global varijable
	global visited
	global ubaci
	global skup
	global rez1
	global rez2
	temporary=[]
	cla = []
	klauzule = []
	cla = cnfConvert(lista)
	Klauzula(cla)

	a = len(clauses)
	
	temporary = cnfConvert(zakljucak)
	Klauzula(temporary)
	count = 0

	for el in clauses[0:a]:
		clauses1.append(UkloniOperator(el))
	
	for el in clauses1:
		nadjiKlauzule(el)
		klauzule.append(ubaci)
		ubaci = []
	
	for elem in clauses[a:]:
		skupPotpore.append(UkloniOperator(elem))

	for el in skupPotpore:
		nadjiKlauzule(el)
		skup.append(ubaci)
		ubaci = []
	clauses1 = []
	skupPotpore = []
	for el in klauzule:
		rez1.append(Istoimeni(el))
		
	for el in skup:
		rez2.append(Istoimeni(el)) 
			
	
	counter = 0
	visited = []
	#g = 1
	while True:
		izbor = izaberi(rez1,rez2)
		maksBroj = len(rez2)
		for el in izbor:
			if el not in visited:
				visited.append(el)
				plSkupPotpore(el[0],el[1])
				counter = counter + 1
				if [] in rez2:
					
					print "Dokazano postupkom skupa potpore =)"
					print "Broj koraka: ",counter
					print "Najveci broj klauzula u memoriji: ",len(rez2)
					for el in rez1:
						if el == []:
							print "NIL"
						else:
							print el		

					print "_  _  _  _  _  _  _  _  _"
					for el in pr:
						if el == []:
							print "NIL"
						else:
							print el		

					return True
		if maksBroj == len(rez2):
			return False
		if rez2 == (rez2 + rez1):
			return False
		rez2 = sorted(rez2, key = len)
	
	
def Klauzula(lista):
	 global clauses
	 global varijable
	 global operatori
	 lijevo = []
	 desno = []
	 pom1 = []
	 pom = [] 
	 pom2 = []
	 
	 for el in lista:
		 if el[0] == '&':
			 
			 if el[1][0] == '&':
				 pom1.append(el[1])
				 Klauzula(pom1)
				 pom1 = []
			 else:
				 if el[1] not in clauses:
					clauses.append(el[1])
			
			 if el[2][0] == '&':
				 pom2.append(el[2])
				 Klauzula(pom2)
				 pom2 = []
			 else:
				 if el[2] not in clauses:
					clauses.append(el[2])
		 elif el[0] in varijable:
			 if el not in clauses:
				clauses.append(el)
		 elif el[0] == '~':
			 if el not in clauses:
				clauses.append(el)
		 else:
			 if el not in clauses:
				clauses.append(el)
		
	
def RezolucijaStrategijaPojednostavljenja(lista,zakljucak):
	
	global clauses
	global clauses1
	global pr
	global skupPotpore
	global elem
	global varijable
	global visited
	global ubaci
	global skup
	global rez1
	global rez2
	temporary=[]
	cla = []
	klauzule = []
	cla = cnfConvert(lista)
	Klauzula(cla)

	a = len(clauses)
	
	temporary = cnfConvert(zakljucak)
	Klauzula(temporary)
	count = 0

	for el in clauses[0:a]:
		clauses1.append(UkloniOperator(el))
	
	for el in clauses1:
		nadjiKlauzule(el)
		klauzule.append(ubaci)
		ubaci = []
	
	for elem in clauses[a:]:
		skupPotpore.append(UkloniOperator(elem))
	
	for el in skupPotpore:
		nadjiKlauzule(el)
		skup.append(ubaci)
		ubaci = []

	clauses1 = []
	skupPotpore = []
	
	for el in klauzule:
		if Valjanost(el):
			continue
		else:
			clauses1.append(el)
			
	for el in skup:
		if Valjanost(el):
			continue
		else:
			skupPotpore.append(el)
	
	for el in clauses1:
		rez1.append(Istoimeni(el))
		
	for el in skupPotpore:
		rez2.append(Istoimeni(el)) 
			
	visited = []
	counter = 0
	
	while True:
		elem = izaberi(rez1,rez2)
		maksBroj = len(rez2)
		for el in elem:
			if el not in visited:
				visited.append(el)
				plMix(el[0],el[1])
				counter = counter + 1
				if [] in rez2:
					
					print "Dokazano postupkom skupa potpore sa strategijom pojednostavljenja=)"
					print "Broj koraka: ",counter
					print "Najveci broj klauzula u memoriji: ",len(rez2) + len (rez1)
					for el in rez1:
						if el == []:
							print "NIL"
						else:
							print el		

					print "_  _  _  _  _  _  _  _  _"
					for el in pr:
						if el == []:
							print "NIL"
						else:
							print el		

					return True
		if maksBroj == len(rez2):
			return False
		if rez2 == (rez2 + rez1):
			return False
		rez2 = sorted(rez2, key = len)
	
	

def cnfConvert(lista):
	global varijable
	global zastavica
	skupPotpore = []
	fin = []
	x = []
	y = []
	tmp = []
	niz1 = []
	niz2 = []
	niz = []
	
	for el in lista:
		if el[0] == '~':
			if len(el[1])>1:
				fin.append(tuple(['~',ukloniEkvivalenciju(el[1])]))
			else:
				fin.append(el)
		else:
			if len(el) > 1:
				fin.append(ukloniEkvivalenciju(el))
			else:
				fin.append(el)
	
	
	for el in fin:
		if el[0] == '~':
			if len(el[1])>1:
				x.append(tuple(['~',ukloniImplikaciju(el[1])]))
			else:
				x.append(el)
		else:
			if len(el) > 1:
				x.append(ukloniImplikaciju(el))
			else:
				x.append(el)
	
	
	for el in x:
		y.append(DeMorganOpet(el))

	
	for el in y:
		niz1.append(DvostrukaNegacija(el))
		
	
	zastavica = True
	while zastavica:
		for el in niz1:
			niz.append(DistributivnostOpet(el))
		if zastavica == True:
			niz1 = niz
			niz = []
			
	
	return niz
	
#################################################################################
#						FUNKCIJE ZA CNF
#################################################################################


def DvostrukaNegacija(lista):
	lijevo = []
	desno = []
	pom = []
	global varijable
	global operatori
	
	if lista[0] in varijable:
		return lista[0]
	elif lista[0] == '~':
		if lista[1] in varijable:
			pom = lista
			return pom
		if lista[1][0] == "~":
			pom = DvostrukaNegacija(lista[1][1])
			return pom
		else:
			lijevo = DvostrukaNegacija(lista[1])
			pom = tuple(['~',lijevo])
			return pom
	else:
		lijevo = DvostrukaNegacija(lista[1])
		desno = DvostrukaNegacija(lista[2])
		pom = [lista[0],lijevo,desno]
		return pom	
	


def DistributivnostOpet(lista):
	global varijable
	global operatori
	global temp
	lijevo =[]
	desno = []
	pom = []
	pom1 = []
	global zastavica
	
	zastavica = False
	
	
	if lista[0] == '|':
		if type(lista[2]) is list and lista[2][0] == '&':			
			pom = ['&',['|',lista[1],lista[2][1]],['|',lista[1],lista[2][2]]]
			zastavica = True
			return pom
		elif type(lista[1]) is list and lista[1][0] == '&':
			pom = ['&',['|',lista[2],lista[1][1]],['|',lista[2],lista[1][2]]]
			zastavica = True
			return pom
		else:
			lijevo = DistributivnostOpet(lista[1])
			desno = DistributivnostOpet(lista[2])
			pom1 = [lista[0], lijevo,desno]
			return pom1
	elif lista[0] in varijable:
		return lista
	elif lista[0] == '~':
		return lista
	elif lista[0] == '&':
		lijevo = DistributivnostOpet(lista[1])
		desno = DistributivnostOpet(lista[2])
		pom1 = [lista[0], lijevo,desno]
		return pom1


def SolveDeMorgan(lista):
	
	if lista[0] == '|':
			return ['&', tuple(['~', lista[1]]), tuple(['~', lista[2]])]
	elif lista[0] == '&':
			return ['|', tuple(['~', lista[1]]), tuple(['~', lista[2]])]
	else:
		return lista


def DeMorganOpet(lista):
	global varijable
	global operatori
	global temp
	lijevo =[]
	desno = []
	pom = []
	pom1 = []
	
	oper = lista[0]

	if oper == '~':
		if lista[1] in varijable:
			return lista
		elif lista[1][0] == '~':
			pom = DeMorganOpet(lista[1][1])
			return pom
		elif lista[1][0] in operatori:
			pom = SolveDeMorgan(lista[1])
			pom = DeMorganOpet(pom)
			return pom
		
	elif oper in varijable:
		return lista
	else:
		lijevo = DeMorganOpet(lista[1])
		desno = DeMorganOpet(lista[2])
		pom1=[lista[0],lijevo,desno]
		return pom1

def Usporedi(lijevo, desno):
	global varijable
	value = True
	
	
	if (lijevo is None) or (desno is None):
		return False
	
	elif type(lijevo) is list and type(desno) is not list:
		return False
		
	elif type(lijevo) is not list and type(desno) is list:
		return False
	
	elif type(lijevo) is tuple and type(desno) is not tuple:
		return False
		
	elif type(lijevo) is not tuple and type(desno) is tuple:
		return False

	elif lijevo[0] in varijable and (desno[0] not in varijable):
		return False
		
	elif (lijevo[0] not in varijable) and desno[0] in varijable:
		return False
	
	elif lijevo[0] in varijable and desno[0] in varijable:
		if lijevo != desno:
			return False
		else:
			return True		
	
	else:
		if len(lijevo) == len(desno):
			for x in range(len(lijevo)):
				if lijevo[x] == desno[x]:
					continue
				else:
					return False
		else:
			return False
						
	return value

	
def faktorizacija(lista):
	
	fi = []
	
	if lista[0] == '~':
		if type(lista[1]) is list or type(lista[1]) is tuple:
			lijevo = faktorizacija(lista[1])
			desno = None
		else:
			lijevo = lista[1]
			desno = None
	else:
		if type(lista[1]) is list or type(lista[1]) is tuple:
			lijevo = faktorizacija(lista[1])
		else:
			lijevo = lista[1]

		if type(lista[2]) is list or type(lista[2]) is tuple:
			desno = faktorizacija(lista[2])
		else:
			desno = lista[2]
					
	pom = Usporedi(lijevo, desno)
	if (pom == True):
		fi = lijevo
	else:
		fi.append(lista[0])
		fi.append(lijevo)
		fi.append(desno)
	
	for el in fi:
		if el is None:
			fi.remove(el)
			fi = tuple(fi)
	
	return fi



def Implikacija(listica,roditelj):
	
	pom = []
	
	if '->' in roditelj:
		pom = ['|',tuple(['~',listica[1]]),listica[2]]
	else:
		pom = listica
		
	return pom
	


	
def ukloniImplikaciju(lista):
	global varijable
	global operatori
	lijevo = []
	desno = []
	pom = []
	elem = []
	
	if lista[0] == '~':
		if type(lista[1]) is list or type(lista[1]) is tuple:
			lijevo = ukloniImplikaciju(lista[1])
			desno = None
		else:
			lijevo = lista[1]
			desno = None
	else:
		if type(lista[1]) is list or type(lista[1]) is tuple:
			lijevo = ukloniImplikaciju(lista[1])
		else:
			lijevo = lista[1]
	
		if type(lista[2]) is list or type(lista[2]) is tuple:
			desno = ukloniImplikaciju(lista[2])
		else:
			desno = lista[2]
	
		
	pom = Implikacija([lista[0], lijevo, desno],[lista[0], lijevo, desno])
	for el in pom:
		if el == None:
			pom.remove(el)
	if "~" in pom:
		pom = tuple(pom)
	return pom



	
def Ekvivalencija(listica,roditelj):
	
	pom = []
	
	if '<->' in roditelj:
		pom = ['&',['|',tuple(['~',listica[1]]), listica[2]],['|',tuple(['~', listica[2]]), listica[1]]]
	else:
		pom = listica
		
	return pom
	



def ukloniEkvivalenciju(lista):
	global varijable
	global operatori
	lijevo = []
	desno = []
	pom = []
	
	if lista[0] == '~':
		if type(lista[1]) is list or type(lista[1]) is tuple:
			lijevo = ukloniEkvivalenciju(lista[1])
			desno = None
		else:
			lijevo = lista[1]
			desno = None
	else:
		if type(lista[1]) is list or type(lista[1]) is tuple:
			lijevo = ukloniEkvivalenciju(lista[1])
		else:
			lijevo = lista[1]

	
		if type(lista[2]) is list or type(lista[2]) is tuple:
			desno = ukloniEkvivalenciju(lista[2])
		else:
			desno = lista[2]
		
	pom = Ekvivalencija([lista[0], lijevo, desno],[lista[0], lijevo, desno])
	for el in pom:
		if el == None:
			pom.remove(el)
	if "~" in pom:
		pom = tuple(pom)
	
	return pom


##################################################################################
#                			ULAZ
##################################################################################


global premise
global zakljucak
global lijeva_strana

print "Unesite formule za proces dokazivanja:"

while True:
	elem = raw_input()
	
	if elem != '1':
		premise.append(elem)
	else:
		break

print "Ukoliko zelite strategiju skupa potpore, unesite 0."
print "Za strategiju skupa potpore sa strategijom pojednostavljenja, unesite 1."

strategija = raw_input()

formule = []
duljina = {}

listica = []

for el in premise:
	listica.append(parsiranje(el))

zakljucak.append(tuple(['~',listica[-1]]))


listica.pop()

for el in listica:
	lijeva_strana.append(el)
listica.insert(len(listica),zakljucak)


plResolution(lijeva_strana,zakljucak,strategija)
