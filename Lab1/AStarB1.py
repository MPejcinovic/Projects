from operator import itemgetter
import os
import sys
from collections import defaultdict
import math
from collections import Counter

roditelj = []

def rekonstrukcija(koord,rjecnik,zastavica):
	global roditelj 
	if (zastavica == 1):
		return
	for el in rjecnik[1]:	
		koordinate = el[1]
		if koordinate == koord:
			if el[3] not in roditelj and el[3] != None:
				roditelj.insert(0,el[3])
				rekonstrukcija(el[3],rjecnik,zastavica)
				return
			else:
				zastavica = 1

def heuristika1(K1, K2):
		return (math.fabs(K1[0] - K2[0]) + math.fabs(K1[1] - K2[1]))

def manhattanDistance(ozn,x,y,manhattan,flag,duljina):
	x1 = ozn[0]
	y1 = ozn[1]
	if (flag):
		distance = 3 * (math.fabs(x1 - x) + math.fabs (y1 - (y + duljina/2)))
	else:
		distance = math.fabs(x1 - x) + math.fabs (y1 - (y + duljina/2))
	manhattan[tuple(ozn+[x,y])] = distance

	
def ManhattanUdaljenost(x1,y1,x2,y2):
	return (math.fabs(x1 - x2) + math.fabs(y1 - y2))



def nasljednici(pocetni, znakovi, indeks,koor):
	
	x = pocetni[1][0]
	y = pocetni[1][1]
	oznaka = pocetni[0]
	roditelj = pocetni[1]
	dist = 0
	if ("T" in oznaka or "S" in oznaka or "P" in oznaka or "C" in oznaka):
		dist = 0
	else:
		dist = int(oznaka)
	udaljenost = pocetni[2]
	listaZaPovratak = []
	
	if (x == 0):
		if (y == 0):
			xR = x
			yR = y + 1
			oznakaR = znakovi[xR][yR]
			if ("P" in oznakaR or ("T" in oznakaR) or ("S" in oznakaR) or ("C" in oznakaR)):
				udaljenostR=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostR = udaljenost + math.fabs(dist - int(oznakaR))
			H = heuristika1([xR,yR],koor)
			HR = udaljenostR + H
			
			xD = x + 1
			yD = y
			oznakaD = znakovi[xD][yD]
			if ("P" in oznakaD or ("T" in oznakaD) or ("S" in oznakaD) or ("C" in oznakaD)):
				udaljenostD=udaljenost + math.fabs(dist - 0)   
			else:
				udaljenostD = udaljenost + math.fabs(dist - int(oznakaD)) 
			H = heuristika1([xD,yD],koor)
			HD = udaljenostD + H
			
			listaZaPovratak.append([oznakaR,[xR,yR],udaljenostR,roditelj,HR])
			listaZaPovratak.append([oznakaD,[xD,yD],udaljenostD,roditelj,HD])
			return listaZaPovratak
		elif (y == indeks):
			
			xL = x
			yL = y - 1
			oznakaL = znakovi[xL][yL]
			if ("P" in oznakaL or ("T" in oznakaL) or ("S" in oznakaL) or ("C" in oznakaL)):
				udaljenostL=udaljenost + math.fabs(dist - 0) 
			else:
				udaljenostL = udaljenost + math.fabs(dist - int(oznakaL)) 
			H = heuristika1([xL,yL],koor)
			HL = udaljenostL + H
			
			xD = x + 1
			yD = y
			oznakaD = znakovi[xD][yD]
			if ("P" in oznakaD or("T" in oznakaD) or ("S" in oznakaD) or ("C" in oznakaD)):
				udaljenostD=udaljenost + math.fabs(dist - 0) 
			else:
				udaljenostD = udaljenost + math.fabs(dist - int(oznakaD)) 
			H = heuristika1([xD,yD],koor)
			HD = udaljenostD + H
			
			listaZaPovratak.append([oznakaL,[xL,yL],udaljenostL,roditelj,HL])
			listaZaPovratak.append([oznakaD,[xD,yD],udaljenostD,roditelj,HD])
			
			return listaZaPovratak
			
		else:	
			xR = x
			yR = y + 1
			oznakaR = znakovi[xR][yR]
			if ("P" in oznakaR or("T" in oznakaR) or ("S" in oznakaR) or ("C" in oznakaR)):
				udaljenostR=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostR = udaljenost + math.fabs(dist - int(oznakaR)) 
			H = heuristika1([xR,yR],koor)
			HR = udaljenostR + H
			
			xD = x + 1
			yD = y
			oznakaD = znakovi[xD][yD]
			if ("P" in oznakaD or("T" in oznakaD) or ("S" in oznakaD) or ("C" in oznakaD)):
				udaljenostD=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostD = udaljenost + math.fabs(dist - int(oznakaD))
			H = heuristika1([xD,yD],koor)
			HD = udaljenostD + H
			
			xL = x
			yL = y - 1
			oznakaL = znakovi[xL][yL]
			if ("P" in oznakaL or("T" in oznakaL) or ("S" in oznakaL) or ("C" in oznakaL)):
				udaljenostL=udaljenost + math.fabs(dist - 0) 
			else:
				udaljenostL = udaljenost + math.fabs(dist - int(oznakaL))
			H = heuristika1([xL,yL],koor)
			HL = udaljenostL + H
		
			listaZaPovratak.append([oznakaR,[xR,yR],udaljenostR,roditelj,HR])
			listaZaPovratak.append([oznakaL,[xL,yL],udaljenostL,roditelj,HL])
			listaZaPovratak.append([oznakaD,[xD,yD],udaljenostD,roditelj,HD])
			
			return listaZaPovratak
			
	elif (x == ((2*(indeks+1))-1)):
		if (y == 0):
			xR = x
			yR = y + 1
			oznakaR = znakovi[xR][yR]
			if ("P" in oznakaR or("T" in oznakaR) or ("S" in oznakaR) or ("C" in oznakaR)):
				udaljenostR=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostR = udaljenost + math.fabs(dist - int(oznakaR))
			H = heuristika1([xR,yR],koor)
			HR = udaljenostR + H
			
			xU = x - 1
			yU = y
			oznakaU = znakovi[xU][yU]
			if ("P" in oznakaU or("T" in oznakaU) or ("S" in oznakaU) or ("C" in oznakaU)):
				udaljenostU=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostU = udaljenost + math.fabs(dist - int(oznakaU))
			H = heuristika1([xU,yU],koor)
			HU = udaljenostU + H
			
			listaZaPovratak.append([oznakaR,[xR,yR],udaljenostR,roditelj,HR])
			listaZaPovratak.append([oznakaU,[xU,yU],udaljenostU,roditelj,HU])
			return listaZaPovratak
		elif (y == indeks):
			
			xL = x
			yL = y - 1
			oznakaL = znakovi[xL][yL]
			if ("P" in oznakaL or("T" in oznakaL) or ("S" in oznakaL) or ("C" in oznakaL)):
				udaljenostL=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostL = udaljenost + math.fabs(dist - int(oznakaL))
			H = heuristika1([xL,yL],koor)
			HL = udaljenostL + H
			
			xU = x - 1
			yU = y
			oznakaU = znakovi[xU][yU]
			if ("P" in oznakaU or("T" in oznakaU) or ("S" in oznakaU) or ("C" in oznakaU)):
				udaljenostU=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostU = udaljenost + math.fabs(dist - int(oznakaU))
			H = heuristika1([xU,yU],koor)
			HU = udaljenostU + H
			
			listaZaPovratak.append([oznakaL,[xL,yL],udaljenostL,roditelj,HL])
			listaZaPovratak.append([oznakaU,[xU,yU],udaljenostU,roditelj,HU])
			
			return listaZaPovratak
			
		else:	
			xR = x
			yR = y + 1
			oznakaR = znakovi[xR][yR]
			if ("P" in oznakaR or("T" in oznakaR) or ("S" in oznakaR) or ("C" in oznakaR)):
				udaljenostR=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostR = udaljenost + math.fabs(dist - int(oznakaR))
			H = heuristika1([xR,yR],koor)
			HR = udaljenostR + H
			
			xU = x - 1
			yU = y
			oznakaU = znakovi[xU][yU]
			if ("P" in oznakaU or("T" in oznakaU) or ("S" in oznakaU) or ("C" in oznakaU)):
				udaljenostU=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostU = udaljenost + math.fabs(dist - int(oznakaU))
			H = heuristika1([xU,yU],koor)
			HU = udaljenostU + H
			
			xL = x
			yL = y - 1
			oznakaL = znakovi[xL][yL]
			if ("P" in oznakaL or("T" in oznakaL) or ("S" in oznakaL) or ("C" in oznakaL)):
				udaljenostL=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostL = udaljenost + math.fabs(dist - int(oznakaL))
			H = heuristika1([xL,yL],koor)
			HL = udaljenostL + H
		
			listaZaPovratak.append([oznakaR,[xR,yR],udaljenostR,roditelj,HR])
			listaZaPovratak.append([oznakaL,[xL,yL],udaljenostL,roditelj,HL])
			listaZaPovratak.append([oznakaU,[xU,yU],udaljenostU,roditelj,HU])
			
			return listaZaPovratak
	else:
		
		if (y == 0):
			
			xR = x
			yR = y + 1
			oznakaR = znakovi[xR][yR]
			if ("P" in oznakaR or("T" in oznakaR) or ("S" in oznakaR) or ("C" in oznakaR)):
				udaljenostR=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostR = udaljenost + math.fabs(dist - int(oznakaR))
			H = heuristika1([xR,yR],koor)
			HR = udaljenostR + H
			
			xU = x - 1
			yU = y
			oznakaU = znakovi[xU][yU]
			if ("P" in oznakaU or("T" in oznakaU) or ("S" in oznakaU) or ("C" in oznakaU)):
				udaljenostU=udaljenost + math.fabs(dist - 0) 
			else:
				udaljenostU = udaljenost + math.fabs(dist - int(oznakaU)) 
			H = heuristika1([xU,yU],koor)
			HU = udaljenostU + H
			
			xD = x + 1
			yD = y
			oznakaD = znakovi[xD][yD]
			if ("P" in oznakaD or("T" in oznakaD) or ("S" in oznakaD) or ("C" in oznakaD)):
				udaljenostD=udaljenost + math.fabs(dist - 0) 
			else:
				udaljenostD = udaljenost + math.fabs(dist - int(oznakaD))
			H = heuristika1([xD,yD],koor)
			HD = udaljenostD + H
			
			listaZaPovratak.append([oznakaR,[xR,yR],udaljenostR,roditelj,HR])
			listaZaPovratak.append([oznakaU,[xU,yU],udaljenostU,roditelj,HU])
			listaZaPovratak.append([oznakaD,[xD,yD],udaljenostD,roditelj,HD])
			
			return listaZaPovratak
		
		elif (y == indeks):
			
			xL = x
			yL = y - 1
			oznakaL = znakovi[xL][yL]
			if ("P" in oznakaL or("T" in oznakaL) or ("S" in oznakaL) or ("C" in oznakaL)):
				udaljenostL=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostL = udaljenost + math.fabs(dist - int(oznakaL))
			H = heuristika1([xL,yL],koor)
			HL = udaljenostL + H
			
			xU = x - 1
			yU = y
			oznakaU = znakovi[xU][yU]
			if ("P" in oznakaU or("T" in oznakaU) or ("S" in oznakaU) or ("C" in oznakaU)):
				udaljenostU=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostU = udaljenost + math.fabs(dist - int(oznakaU))
			H = heuristika1([xU,yU],koor)
			HU = udaljenostU + H
			
			xD = x + 1
			yD = y
			oznakaD = znakovi[xD][yD]
			if ("P" in oznakaD or("T" in oznakaD) or ("S" in oznakaD) or ("C" in oznakaD)):
				udaljenostD=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostD = udaljenost + math.fabs(dist - int(oznakaD))
			H = heuristika1([xD,yD],koor)
			HD = udaljenostD + H
			
			
			listaZaPovratak.append([oznakaL,[xL,yL],udaljenostL,roditelj,HL])
			listaZaPovratak.append([oznakaU,[xU,yU],udaljenostU,roditelj,HU])
			listaZaPovratak.append([oznakaD,[xD,yD],udaljenostD,roditelj,HD])
			
			return listaZaPovratak
			
		else:
			xD = x + 1
			yD = y 
			oznakaD = znakovi[xD][yD]
			if ("P" in oznakaD or("T" in oznakaD) or ("S" in oznakaD) or ("C" in oznakaD)):
				udaljenostD=udaljenost + math.fabs(dist - 0) 
			else:
				udaljenostD = udaljenost + math.fabs(dist - int(oznakaD))
			H = heuristika1([xD,yD],koor)
			HD = udaljenostD + H
			
			xR = x
			yR = y + 1
			oznakaR = znakovi[xR][yR]
			if ("P" in oznakaR or("T" in oznakaR) or ("S" in oznakaR) or ("C" in oznakaR)):
				udaljenostR=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostR = udaljenost + math.fabs(dist - int(oznakaR))
			H = heuristika1([xR,yR],koor)
			HR = udaljenostR + H
			
			xU = x - 1
			yU = y
			oznakaU = znakovi[xU][yU]
			if ("P" in oznakaU or("T" in oznakaU) or ("S" in oznakaU) or ("C" in oznakaU)):
				udaljenostU=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostU = udaljenost + math.fabs(dist - int(oznakaU))
			H = heuristika1([xU,yU],koor)
			HU = udaljenostU + H
			
			xL = x
			yL = y - 1
			oznakaL = znakovi[xL][yL]
			if ("P" in oznakaL or("T" in oznakaL) or ("S" in oznakaL) or ("C" in oznakaL)):
				udaljenostL=udaljenost + math.fabs(dist - 0)
			else:
				udaljenostL = udaljenost + math.fabs(dist - int(oznakaL))
			H = heuristika1([xL,yL],koor)
			HL = udaljenostL + H
			
			listaZaPovratak.append([oznakaR,[xR,yR],udaljenostR,roditelj,HR])
			listaZaPovratak.append([oznakaL,[xL,yL],udaljenostL,roditelj,HL])
			listaZaPovratak.append([oznakaD,[xD,yD],udaljenostD,roditelj,HD])
			listaZaPovratak.append([oznakaU,[xU,yU],udaljenostU,roditelj,HU])
			
			return listaZaPovratak


ulaz = open('primjer3.txt', 'rb')
ulazni_niz = ulaz.readlines()
ulaz.close()

posjeceni = {}
putevi1 = {}
PTSLijevo = {}

otvoreni = []
naslj = []
rj = defaultdict(list)
i = 0
znakovi=[]
TFind = 0
SFind = 0
OznakaT = ""
OznakaS = ""


for lines in ulazni_niz:
	line = lines.rstrip('\n')
	line = line.split(' ')
	znakovi.append(line)

znakovi1 = []
znakovi2 = []

duljina = len(znakovi)

for i in range(0, duljina):
	znakici = []
	for j in range(0, duljina/2):
		znakici.append(znakovi[i][j])
	znakovi1.append(znakici)

for i in range(0, duljina):
	znakici = []
	for j in range(duljina/2, duljina):
		znakici.append(znakovi[i][j])
	znakovi2.append(znakici)


TSLijevo = []

for i in range(0, duljina):
	for j in range(0, duljina/2):
		if (("T" in znakovi1[i][j]) or ("S" in znakovi1[i][j])):
			TSLijevo.append([i,j])
		elif "P" in znakovi1[i][j]:
			xP = i
			yP = j
		else:
			continue

TSDesno = []

for i in range(0, duljina):
	for j in range(0, duljina/2):
		if (("T" in znakovi2[i][j]) or ("S" in znakovi2[i][j])):
			TSDesno.append([i,j])
		elif "C" in znakovi2[i][j]:
			xC = i
			yC = j
			kC2=[xC,yC]
			kC1=[xC,yC+duljina/2]
		else:
			continue

TeleportLijevo = {}
for teleport in TSLijevo:
	ud = 0
	x = teleport[0]
	y = teleport[1]
	for el in TSLijevo:
		x1 = el[0]
		y1 = el[1]
		if ((x1 != x or y1 !=y) and (znakovi1[x1][y1] == znakovi1[x][y])):
			prvi = tuple(el + teleport)
			if prvi not in TeleportLijevo:
				ud = ManhattanUdaljenost(x,y,x1,y1)
				TeleportLijevo[tuple(teleport + el)] = ud
			else:
				continue

for teleport in TSDesno:
	ud = 0
	x = teleport[0]
	y = teleport[1]
	for el in TSDesno:
		x1 = el[0]
		y1 = el[1]
		if ((x1 != x or y1 !=y) and (znakovi2[x1][y1] == znakovi2[x][y])):
			prvi = tuple([x1, y1 + duljina/2] + [x, y + duljina/2])
			if prvi not in TeleportLijevo:
				ud = ManhattanUdaljenost(x,y,x1,y1)
				TeleportLijevo[tuple([x,y+duljina/2]+[x1,y1+duljina/2])] = ud
			else:
				continue


cvorovi1 = 0
for el in TSLijevo:
	
	start = ["P",[xP,yP],0,None]
	lista = []
	lista.append(start)
	
	x1 = el[0]
	y1 = el[1]
	KTSLijevo = [x1,y1]
	visited = {}
	listaNatrag1 = []
	pomocnaLista = []
	
	while(lista):
		pom = lista[0]
		if (pom not in listaNatrag1):
			listaNatrag1.append(pom)
		if (pom[1] not in otvoreni):
			otvoreni.append(pom[1])
		lista.remove(pom)
		if (pom[1] == KTSLijevo):
			pomocnaLista.append(pom[2])
			pomocnaLista.append(listaNatrag1)
			PTSLijevo[tuple(KTSLijevo)] = pomocnaLista
			break
		visited[tuple(pom[1])] = pom[2]
		naslj = nasljednici(pom,znakovi1, duljina/2-1,kC1)
		while(naslj):
			if ((tuple(naslj[0][1])) in visited.keys()):
				naslj.remove(naslj[0])
			else:
				lista.append(naslj[0])
				naslj.remove(naslj[0])
		lista.sort(key=itemgetter(4))

manhattan = {}

for el in TSLijevo:
	for i in range(0, duljina):
		for j in range (0, duljina/2):
			if znakovi1[el[0]][el[1]] == znakovi2[i][j]:
				manhattanDistance(el,i,j,manhattan,0, duljina)
			elif (("S" in znakovi1[el[0]][el[1]]) and ("S" in znakovi2[i][j])):
				manhattanDistance(el, i, j, manhattan,1,duljina)
			else:
				continue
				

Cilj = {}
for el in TSDesno:
	VisitedAgain = {}
	x1 = el[0]
	y1 = el[1]
	ozn = znakovi2[x1][y1]
	start = [ozn,[x1,y1],0,None]
	listaC = []
	listaC.append(start)
	KTSDesno = [x1,y1]
	visited = {}
	listaNatrag1 = []
	pomocnaLista = []
	while(listaC):
		pom = listaC[0]
		if(pom not in listaNatrag1):
			listaNatrag1.append(pom)
		if (pom[1] not in otvoreni):
			otvoreni.append(pom[1])
		listaC.remove(pom)
		if (pom[0] == "C" ):
			xC = pom[1][0]
			yC = pom[1][1]
			pomocnaLista.append(pom[2])
			pomocnaLista.append(listaNatrag1)
			Cilj[tuple(KTSDesno)] = pomocnaLista
			break
		VisitedAgain[tuple(pom[1])] = pom[2]
		naslj = nasljednici(pom,znakovi2, duljina/2-1,kC2)
		while(naslj):
			if (((tuple(naslj[0][1])) in VisitedAgain.keys()) or("T" in naslj[0][0]) or ("SL" in naslj[0][0])):
				naslj.remove(naslj[0])
			else:
				listaC.append(naslj[0])
				naslj.remove(naslj[0])
		listaC.sort(key=itemgetter(4))
        

maksimum = 10000	
for key1 in PTSLijevo:
	udaljenost = 0
	for key2 in manhattan:
		x = key2[0]
		y = key2[1]
		koord1 = [x,y]
		
		x1 = key1[0]
		y1 = key1[1]
		koord2 = [x1,y1]
		
		if koord1 == koord2:
			for key3 in Cilj:
				x2 = key3[0]
				y2 = key3[1]
				koord3 = [x2,y2]
				x3 = key2[2]
				y3 = key2[3]
				koord4 = [x3,y3]
				if koord3 == koord4:
					udaljenost = PTSLijevo[key1][0] + manhattan[key2] + Cilj[key3][0]
					if udaljenost < maksimum:
						maksimum = udaljenost
						r1 = key1
						r2 = key2
						r3 = key3
				else:
					continue
print "Minimal cost: "  + str(int(maksimum))

k1 = [r1[0],r1[1]]
k2 = [xC,yC]
put1 = []
put2 = []
rekonstruiraniPut = []
zastavica1 = 0
zastavica2 = 0


cvorovi1 = cvorovi1 + len(PTSLijevo[r1][1]) + len(Cilj[r3][1])
print "Opened nodes: " + str(int(cvorovi1))

rekonstrukcija(k1,PTSLijevo[r1],zastavica1)
put1 = roditelj
roditelj =[]
rekonstrukcija(k2,Cilj[r3],zastavica2)
put2 = roditelj

for el in put1:
	x = el[0] + 1
	y = el[1] + 1 
	c = [x,y]
	rekonstruiraniPut.append(c)


x1 = r2[0]
y1 = r2[1]

rekonstruiraniPut.append([x1 + 1,y1 + 1])
for el in put2:
	x = el[0] + 1
	y = el[1] + 1 + duljina/2
	c = [x,y]
	rekonstruiraniPut.append(c)

rekonstruiraniPut.append([xC + 1,yC + 1 + duljina/2])

print "Path:"
for el in rekonstruiraniPut:
	if el == rekonstruiraniPut[-1]:
		print "(" + str(int(el[0])) + "," + str(int(el[1])) + ")"
	else:
		print "(" + str(int(el[0])) + "," + str(int(el[1])) + ") ->"
