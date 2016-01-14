package hr.fer.zemris.apr.lab4;

import java.io.File;
import java.io.PrintStream;

import apr.lab1.Matrica;

public class RungeKutta implements Algoritam {

	private double t;
	private double[] interval;
	private Matrica a;
	private Matrica x;
	private Matrica b;
	private int brKoraka;
	private int br;
	private Matrica m1;
	private Matrica m2;
	private Matrica m3;
	private Matrica m4;
	
	public RungeKutta(double t, double[] interval, Matrica a, Matrica x, Matrica b, int br) {
		this.t = t;
		System.out.println("t " + t);
		this.interval = interval;
		this.a = a;
		this.x = x;
		this.b = b;
		this.brKoraka = (int) ((interval[1] - interval[0]) / t);
		this.br = br; 
		this.m1 = new Matrica();
		this.m2 = new Matrica();
		this.m3 = new Matrica();
		this.m4 = new Matrica();
		m1.inicijaliziraj(this.b.getRow(), this.b.getCol());
		m2.inicijaliziraj(this.b.getRow(), this.b.getCol());
		m3.inicijaliziraj(this.b.getRow(), this.b.getCol());
		m4.inicijaliziraj(this.b.getRow(), this.b.getCol());
	}

	@Override
	public void algorithm() {
		int brojac = 0;
		double[][] vrijednost = new double[x.getRow()][this.brKoraka];
		double pomak = this.interval[0];

		for (double i = this.interval[0]; i < this.interval[1]; i += this.t) {
			odrediM();
			Matrica tmp = new Matrica();
			tmp.inicijaliziraj(x.getRow(),x.getCol());
			tmp = Matrica.scalarMultiplication(Matrica.add(m1 ,Matrica.add(Matrica.scalarMultiplication(m2, 2), Matrica.add(Matrica.scalarMultiplication(m3, 2), m4))), this.t / 6);
			this.x = Matrica.add(this.x, tmp);
			if (brojac % br == 0){
				x.printMatrixOnScreen();
				System.out.println();
			}
			for (int j = 0; j < x.getRow(); j++) 
				vrijednost[j][brojac] = x.getElement(j, 0);
			brojac ++;
			if (brojac == this.brKoraka)
				break;
		}
		
		try{
			PrintStream fw = new PrintStream(new File("C:\\Users\\Matea\\Desktop\\RungeKutta.txt"));
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

	private void odrediM() {
		Matrica k = Matrica.add(Matrica.multiplicate(this.a, this.x), this.b);
		for (int i = 0; i < this.m1.getRow(); i++) {
			for (int j = 0; j < this.m1.getCol(); j++) {
				this.m1.getMatrica().get(i).set(j, k.getElement(i, j));
			}
		}
		Matrica l = Matrica.add(Matrica.multiplicate(this.a, Matrica.add(this.x, Matrica.scalarMultiplication(k, this.t * 0.5))), this.b);
		for (int i = 0; i < this.m2.getRow(); i++) {
			for (int j = 0; j < this.m2.getCol(); j++) {
				this.m2.getMatrica().get(i).set(j, l.getElement(i, j));
			}
		}
		Matrica h = Matrica.add(Matrica.multiplicate(this.a, Matrica.add(this.x, Matrica.scalarMultiplication(l, this.t * 0.5))), this.b);
		for (int i = 0; i < this.m3.getRow(); i++) {
			for (int j = 0; j < this.m3.getCol(); j++) {
				this.m3.getMatrica().get(i).set(j, h.getElement(i, j));
			}
		}
		Matrica g = Matrica.add(Matrica.multiplicate(this.a, Matrica.add(this.x, Matrica.scalarMultiplication(h, this.t))), this.b);
		for (int i = 0; i < this.m4.getRow(); i++) {
			for (int j = 0; j < this.m4.getCol(); j++) {
				this.m4.getMatrica().get(i).set(j, g.getElement(i, j));
			}
		}
	}
}
