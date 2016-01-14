import multiprocessing
import time
import os
import sys

global redovi
global t
global prviC
global odgovori
global n
global odgodjenOdg


def udjiuKO(k):
	print 'Proces %s usao u kriticni odsjecak!' % (k)
	for i in range(5):
		print "Ispisujem broj: ", i+1
		time.sleep(1)
def cekajNaKO(k):
	global t
	global prviC
	global redovi
	global odgovori
	global n
	global odgodjenOdg
	
	while True:
		if not(redovi[k].empty()):
			el = redovi[k].get()
			if (el[0] == "Z"):
				t[k] = max(t[k], el[1][1]) + 1
				if ((prviC[k] > el[1][1]) or ((prviC[k] == el[1][1]) and (k > el[1][0]))):
					redovi[el[1][0]].put(tuple(["O", tuple([k, el[1][1]])]))
					print 'Proces %s salje odgovor procesu %s!' % (k, el[1][0])
				else:
					odgodjenOdg[k].append(el[1][0]) 
			else:
				odgovori[k] = odgovori[k] + 1
				if (odgovori[k] == n - 1):
					odgovori[k] = 0
					break
				else:
					pass
		else:
			time.sleep(0.1)
					   			   
def traziUlazKO(k):
	global n
	global redovi
	global t
	global prviC
	
	for i in range(n):
		if (i != k):
			print 'Proces %s salje zahtjev procesu %s!' % (k, i)
			redovi[i].put(tuple(["Z", tuple([k, t[k]])]))
	prviC[k] = t[k]


def izadjiKO(k):
	global odgodjenOdg
	global t
	
	
	for el in odgodjenOdg[k]:
		print 'Proces %s salje odgovor procesu %s!' % (k, el)
		redovi[el].put(tuple(["O", tuple([k, t[k]])]))
	odgodjenOdg[k] = []

def isprazniRed(k):
	global redovi
	global t
	while(True):
		if not(redovi[k].empty()):
			el = redovi[k].get()
			print 'Proces %s salje odgovor procesu %s!' % (k, el[1][0])
			redovi[el[1][0]].put(tuple(["O", tuple([k, t[k]])]))
		else:
			break

def radi(k ):
	global redovi
	global t
	global odgodjenOdg

	for i in range(2):
		traziUlazKO(k)
		cekajNaKO(k)
		udjiuKO(k)
		izadjiKO(k)
	time.sleep(2)
	isprazniRed(k)


if __name__  == '__main__':
	redovi = {}
	odgovori = []
	odgodjenOdg = []
	prviC = []
	q = []
	t = []
	print "Koliko procesa zelite sinkronizirati?"
	n = int(raw_input())
	for i in range(n):
		t.append(0)
		redovi[i] = multiprocessing.Queue()
		odgovori.append(0)
		odgodjenOdg.append([])
		prviC.append(0)
	Workers = [multiprocessing.Process(target = radi, args = (l, )) for l in range(n)]
	for each in Workers:
		each.start()

