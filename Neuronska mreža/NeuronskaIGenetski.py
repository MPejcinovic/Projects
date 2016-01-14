import random
import math
import sys

def podaci():
	print "Unesite broj neurona u skrivenom sloju: "
	Skriveni = int(raw_input())
	
	print "Unesite broj kromosoma: "
	BrKromosoma = int(raw_input())
	
	print "Unesite dopusteni iznos ukupne pogreske: "
	Pogreska = float(raw_input())
	
	print "Unesite broj iteracija: "
	BrIteracija = int(raw_input())
	
	print "Unesite K: "
	K = float(raw_input())
	
	print "Unesite postotak za mutaciju: "
	Mutacija = float(raw_input())
	
	return Skriveni, BrKromosoma, Pogreska, BrIteracija, K, Mutacija

def testiranje(Vel, Najbolji, izlazna_lista):
	fail = 0
	for i in range(Vel):
		izlazi = []
		izlaz = Najbolji[-1]
		for l in range(Skriveni):
			izlazi.append(1/(1+math.exp(Najbolji[l] * izlazna_lista[i][0] + Najbolji[l + Skriveni])))
		for l in range(Skriveni):
			izlaz = izlaz + izlazi[l] * Najbolji[2*(Skriveni) + l]
		fail = fail + math.pow((izlaz - izlazna_lista[i][1]),2)
		print "%-5s %-6s %-7s" % (izlazna_lista[i][0],izlazna_lista[i][1],izlaz)
	fail = fail/BrKromosoma
	print "Pogreska na skupu za ispitivanje je ",fail


def postaviTezine(Kromosom):
	for element in range(BrKromosoma):
		tezina = []
		for i in range(1 + 3*Skriveni):
			tezina.append(random.uniform(-1,1))
		Kromosom[element] = tezina
	return Kromosom

def ucenje(Skriveni, BrKromosoma, Pogreska, BrIteracija, K, Mutacija, minPogreska):
	brojac = 0
	for i in range(BrIteracija):
		brojac += 1
		bestFit = 0
		pogreska = [0 for j in range(BrKromosoma)]
		fjaDobrote = [0 for j in range(BrKromosoma)]

		for j in range(BrKromosoma):
			for k in range(brel):
				izlazi = []
				izlaz = Kromosom[j][-1]
				for l in range(Skriveni):
					izlazi.append(1/(1+math.exp(Kromosom[j][l] * ulazna_lista[k][0] + Kromosom[j][l + Skriveni])))
				for l in range(Skriveni):
					izlaz = izlaz + izlazi[l] * Kromosom[j][2*(Skriveni) + l]
				pogreska[j] = pogreska[j] +math.pow((izlaz - ulazna_lista[k][1]),2)
			pogreska[j] = (pogreska[j]/BrKromosoma)
			fjaDobrote[j] = 1/pogreska[j]
			if(pogreska[j] < minPogreska):
				minPogreska = pogreska[j]
				bestFit = j
	
		UKGreska = 0.0
		zbrojFja = 0
		for el in range(BrKromosoma):
			UKGreska = UKGreska + pogreska[j]
			zbrojFja = zbrojFja + fjaDobrote[j]
		print "Iteracija: " + str(i + 1) + ",   ukupna greska: " + str(UKGreska/BrKromosoma) + " , greska najbolje jedinke:  " + str(pogreska[bestFit])
	
		if pogreska[bestFit] < Pogreska:
			print '\nSlijedi testiranje na testnom skupu\n'
			for el in range(1 + 3*Skriveni):
				Najbolji[el] = Kromosom[bestFit][el]
			break
	
	 
		pom = 0
		Sum = 0
		Izr = []
		for m in range(BrKromosoma):
			Sum += fjaDobrote[m]/zbrojFja
			Izr.append(Sum)
		
		pomocni[0] = Kromosom[bestFit]
		for el in range(1,BrKromosoma):
			FParent = random.uniform(0, 1)
			SParent = random.uniform(0, 1)	
			p1 = p2 = 0
			for g in range(BrKromosoma):
				if FParent < Izr[g]:
					p1 = g
					break
			for f in range(BrKromosoma):
				if SParent < Izr[g]:
					p2 = g
					break
			pomic = []
			for j in range(3*Skriveni + 1):
				pomic.append((Kromosom[p1][j] + Kromosom[p2][j])/2)
			pomocni[el] = pomic
			for j in range(3*Skriveni + 1):
				index = random.random()
				if (index < Mutacija):
					pomocni[el][j] += random.normalvariate(0,K)
	
		for j in range(BrKromosoma):
			Kromosom[j] = pomocni[j]

	if brojac == BrIteracija:
		print "Vrijednost manja ili jednaka zadanoj pogresci nije pronadjena. Ponovite ucenje na skupu za treniranje." 
		Najbolji[0] = "Greska"
	
	return Najbolji



pomocni = {}
Kromosom = {}
ulaz = open('train-set.txt','rb')
ulazni_niz = ulaz.readlines()
ulaz.close()

ulazna_lista = []
for el in ulazni_niz[1:]:
	el = el.rstrip('\n').split(' ')
	ulazna_lista.append((float(el[0]),float(el[1])))

izlazna_lista = []
ulaz = open('test-set.txt','rb')
ulazni_niz = ulaz.readlines()
ulaz.close()

for el in ulazni_niz[1:]:
	el = el.rstrip('\n').split(' ')
	izlazna_lista.append((float(el[0]),float(el[1])))
	
Vel = len(izlazna_lista)

brel = len(ulazna_lista)
minPogreska = sys.float_info.max
odabran = []

Skriveni, BrKromosoma, Pogreska, BrIteracija, K, Mutacija = podaci()
Kromosom = postaviTezine(Kromosom)

for i in range(BrKromosoma):
	pomocni[i] = []

Najbolji = [0 for el in range(1 + 3*Skriveni)]

Najbolji = ucenje(Skriveni, BrKromosoma, Pogreska, BrIteracija, K, Mutacija, minPogreska)


if Najbolji[0] == "Greska":
	exit(1)


fail = 0
print "Ulaz  Izlaz  Dobiveni izlaz"

testiranje(Vel, Najbolji, izlazna_lista)

while(1):
	print "Unesite novi uzorak: "
	uzorak = float(raw_input())
	izlazi = []
	izlaz = Najbolji[-1]
	for l in range(Skriveni):
		izlazi.append(1/(1+math.exp(Najbolji[l] * uzorak + Najbolji[l + Skriveni])))
	for l in range(Skriveni):
		izlaz = izlaz + izlazi[l] * Najbolji[2*(Skriveni) + l]
	print "Izlaz je: ",izlaz
		
