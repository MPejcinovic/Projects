import sys
import re
import os


pomocni = {}
konfliktniSkup = []
Stog = []
radnaMemorija =[]
unos = ""
rjecnik = {}

	
	
def MatematickaUsporedba(lista, el):
	global unos
	
	if isinstance(unos, basestring):
		return False
	
	if ">" in lista[0]:
		return el > lista[1]
	elif "<" in lista[0]:
		return el < lista[1]
	elif "<=" in lista[0]:
		return el <= lista[1]
	elif ">=" in lista[0]:
		return el >= lista[1]
	
		

def IntervalnaUsporedba(lista, el):
	global unos
	if el >= lista[0] and el <= lista[1]:
		return True
	else:
		return False


def Usporedba(pravilo,el):
	if type(pravilo[1]) is list:
		if pravilo[1][0] not in "<=" or pravilo[1][0] not in ">=" or pravilo[1][0] not in "<" or pravilo[1][0] not in ">":
			if pravilo[1][0].isdigit():
				return (IntervalnaUsporedba(pravilo[1],el[1]))
			else:
				for elem in pravilo[1]:
					if el[1] in elem:
						return True
					else:
						continue
				return False
		else:
			return MatematickaUsporedba(pravilo[1],el[1])
	else:
		if el[1] == pravilo[1]:
			return True
		else:
			return False


def Ispitaj(pravilo):
	global radnaMemorija
	global unos
	for el in radnaMemorija:
		if el[0] == pravilo[0]:
			a = Usporedba(pravilo, el)
			if a == False:
				return True
	return False				


def checking(pravilo):
	global radnaMemorija
	global unos
	
	for el in radnaMemorija:
		if el[0] == pravilo[0]:
			a = Usporedba(pravilo,el)
			if a == True:
				return True
	return False
				
	
def PremiseNotOK(prioritet, vrh, PP):
	global unos
	pravilo = PP[prioritet]
	
	for x in range(len(pravilo[0])-1):
		if Ispitaj(pravilo[0][x]):
			return True
		else:
			continue
	return False

	
def PremiseOK(prioritet, vrh, PP):
	global unos
	g = False
	pravilo = PP[prioritet]
	for x in range(len(pravilo[0])-1):
		print pravilo[0][x]
		g = checking(pravilo[0][x])
		if g==True:
			continue
		else:
			return False
	return True
	
	
	
def IzdvojiPravila(PP, vrh):
	nizic = []
	for key in PP:
		if PP[key][1][0] == vrh:
			nizic.append(key)
	return nizic


def pokreni(PP):
	global Stog
	global radnaMemorija
	global unos
	premise = False
	konfliktniSkup = []
	
	while(Stog or premise):
		vrh = Stog[-1]
		if (premise == False):
			konfliktniSkup = IzdvojiPravila(PP,vrh)
			konfliktniSkup.sort(key=int)
		if not konfliktniSkup:
			Stog.pop();
			continue
		print "Stog je: ", Stog
		print "U memoriji je: ", radnaMemorija
		print "Konfliktni skup je: ", konfliktniSkup
		premise = False	
		k = PremiseOK(konfliktniSkup[0], vrh, PP)
		if k == True:	
			elem = PP[konfliktniSkup[0]][1]
			unos = elem[1]
			radnaMemorija.append([elem[0], unos])
			print "Pravilo je uspjesno izvedeno."
			try:
				del PP[konfliktniSkup[0]]
			except KeyError:
				pass
			
			Stog.pop()
			continue
		
			
		elif PremiseNotOK(konfliktniSkup[0], vrh, PP):
			print "Ne moze se naci pravilo koje izvodi potrebnu vrijednost tekuceg parametra."
			try:
				del PP[konfliktniSkup[0]]
			except KeyError:
				pass
			continue
		
		elif TraziPravilo(konfliktniSkup[0], vrh, PP):
			print "Pravilo se trazi na desnoj strani."
			continue
		
		elif NemaPravila(konfliktniSkup[0], vrh, PP):
			 premise = True
			 continue

		Stog.pop()
	
	print "Kraj"
	for el in radnaMemorija:
		print el[0] + " = " + el[1]
	####################SAD STAVI ISPIS OVDJE =)  ########################
		
def KorisnickiUnos(pravilo):
	global unos
	global radnaMemorija
	global rjecnik
	print "Unesite vrijednost za ",pravilo
	print "Moguce vrijednosti su: ", rjecnik[pravilo]
	unos = raw_input()
	radnaMemorija.append([pravilo, unos])	
		
		
		
def NemaPravila(prioritet, vrh, PP):
	pravilo = PP[prioritet]
	global unos
	global radnaMemorija
	
	
	for x in range(len(pravilo[0])-1):
		a = provjeri(pravilo[0][x])
		if a == False:
			KorisnickiUnos(pravilo[0][x][0])
			return True
	return False


def provjeri(pravilo):
	global radnaMemorija
	
	for el in radnaMemorija:
		if el[0] == pravilo[0]:
			return True
		else:
			continue
	return False	
	
	
	
def IzvodiDesnaStrana(pravilo, PP):
	for key in PP:
		if PP[key][1][0] == pravilo[0]:
			return True
	return False
	
	
	
def TraziPravilo(prioritet, vrh, PP):
	global unos
	global radnaMemorija
	
	pravilo = PP[prioritet]
	for x in range(len(pravilo[0])-1):
		a = provjeri(pravilo[0][x])
		b = IzvodiDesnaStrana(pravilo[0][x], PP)
		if a == False and b == True:
			Stog.append(pravilo[0][x][0])
			return True
	return False
	


def parsirajIzraz(el):
	left = el.split(' ')
	if len(left) == 3:
		if '<' in left[2][0] or '>' in left[2][0]:
			if '=' in left[2][1]:
				pom1 = left[2][:2]
				pom2 = left[2][2:]
			else:
				pom1 = left[2][0]
				pom2 = left[2][1:]	
			return [left[0], [pom1, pom2]]
		elif '|' in left[2]:
			pom = left[2].split('|')
			return [left[0], pom]
		elif '-' in left[2]:
			pom = left[2].split('-')
			return [left[0], [pom[0], pom[1]]]
		else:
			return [left[0], left[2]]
	


def parsiraj(elem):
	pom = []
	niz = []
	el = elem.split(' IF ')
	prioritet = el[0]
	lijevo = el[1].split(' & ')
	for el in lijevo:
		pom.append(parsirajIzraz(el))
	pom.append(prioritet)
	return pom

global rjecnik

ulaz = open('pravila.txt','rb')
ulazni_niz = ulaz.readlines()
ulaz.close()

ulaz = open('varijable.txt','rb')
ulaz_niz = ulaz.readlines()
ulaz.close()

pravila = []
for elem in ulazni_niz:
	el = elem.rstrip('\n')
	pravila.append(el)
	
varijable = []
for elem in ulaz_niz:
	el = elem.rstrip('\n')
	el = el.strip('\r')
	varijable.append(el)
	
for el in varijable:
	elem = el.split(' = ')
	value = elem[1].split('|')
	rjecnik[elem[0]] = value
	
si = iter(pravila)
lista = [c+next(si, '') for c in si]

povratak = []
uvjet = []
global Stog

for el in lista:
	elem = el.split('THEN ')
	povratak.append(parsirajIzraz(elem[1]))
	uvjet.append(parsiraj(elem[0]))

PP = {}

for x in range(len(povratak)):
	PP[uvjet[x][-1]] = [uvjet[x], povratak[x]]


print "Unesite hipotezu: "

hipoteza = raw_input()

Stog.insert(0,hipoteza)

pokreni(PP)
