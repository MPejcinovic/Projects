package hr.fer.zemris.apr.lab4;

import java.io.File;
import java.io.PrintStream;

import apr.lab1.Matrica;

public class Trapez implements Algoritam {

	private double t;
	private double[] interval;
	private Matrica a;
	private Matrica x;
	private Matrica b;
	private Matrica r;
	private Matrica s;
	private int br;
	private int brKoraka;
	
	public Trapez(double t, double[] interval, Matrica a, Matrica x, Matrica b, int br) {
		this.t = t;
		this.interval = interval;
		this.a = a;
		this.x = x;
		this.b = b;
		this.br = br;
		this.brKoraka = (int) ((interval[1] - interval[0]) / t);
		r = new Matrica();
		s = new Matrica();
		r.inicijaliziraj(a.getRow(), a.getCol());
		s.inicijaliziraj(a.getRow(), b.getCol());
	}

	@Override
	public void algorithm() {
		int brojac = 0;
		double[][] vrijednost = new double[x.getRow()][this.brKoraka];
		
		izracunajMatrice();
		for (double i = this.interval[0]; i < this.interval[1]; i += this.t) {
			izracunaj();
			if (brojac % br == 0){
				x.printMatrixOnScreen();
				System.out.println();
			}
			for (int j = 0; j < x.getRow(); j++) {
				vrijednost[j][brojac] = x.getElement(j, 0);
			}
			brojac++;
			if (brojac == this.brKoraka)
				break;
		}
		try{
			PrintStream fw = new PrintStream(new File("C:\\Users\\Matea\\Desktop\\Trapez.txt"));
			fw.println(this.t);
			for (int i = 0; i < this.brKoraka; i++) {
				String zapis = "";
				for (int j = 0; j < x.getRow(); j++) {
					zapis += vrijednost[j][i]  + " ";
				}
				fw.print(zapis);
				fw.println();
			}
			fw.close();
		}catch(Exception ex){
			ex.printStackTrace();
		}
	}

	private void izracunaj() {
		this.x = Matrica.add(this.s, Matrica.multiplicate(this.r, this.x));;
	}

	private void izracunajMatrice() {
		Matrica I = Matrica.vratiJedinicnu(this.a.getRow(), this.a.getCol());
		Matrica rez = Matrica.scalarMultiplication(this.a, t / 2);
		Matrica tmp = Matrica.subtract(I, rez);
		tmp = tmp.izracunajInverz();
		Matrica h = Matrica.multiplicate(tmp, Matrica.add(I, rez));
		Matrica p = Matrica.multiplicate(Matrica.scalarMultiplication(tmp, t*2), this.b);
		for (int i = 0; i < this.r.getRow(); i++) {
			for (int j = 0; j < this.r.getCol(); j++) {
				this.r.getMatrica().get(i).set(j, h.getElement(i, j));
			}
		}
		for (int i = 0; i < this.s.getRow(); i++) {
			for (int j = 0; j < this.s.getCol(); j++) {
				this.s.getMatrica().get(i).set(j, p.getElement(i, j));
			}
		}
	}

}
