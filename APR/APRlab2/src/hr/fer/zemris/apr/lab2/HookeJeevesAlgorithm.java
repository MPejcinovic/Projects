package hr.fer.zemris.apr.lab2;

public class HookeJeevesAlgorithm {
	
	private Funkcija f;
	private double[] x0;
	private double[] dx;
	private double[] vektor;

	public HookeJeevesAlgorithm(Funkcija f, double[] tocka, double[] vektorDx, double[] vektor){
		this.f = f;
		this.x0 = tocka;
		this.dx = vektorDx;
		this.vektor = vektor;
		algorithm();
	}
	
	private void algorithm(){
		int br = 0;
		int vel = x0.length;
		double[] xp = new double[vel];
		double[] xb = new double[vel];
		
		for (int i = 0; i < vel; i++) {
			xp[i] = xb[i] = x0[i];
		}
		
		while(!check()){
			br ++;
			double[] xn = istrazi(xp, dx);
			if (f.calculate(xn) < f.calculate(xb)){
				for (int i = 0; i < vel; i++)
					xp[i] = 2 * xn[i] - xb[i];
				for (int i = 0; i < vel; i++) 
					xb[i] = xn[i];
			}
			else{
				for (int i = 0; i < dx.length; i++) 
					dx[i] *= 0.5;
				for (int i = 0; i < vel; i++) 
					xp[i] = xb[i];
			}
		}
		String rjesenje = "Rjesenje je: [ ";
		for (int i = 0; i < xb.length; i++) 
			rjesenje += xb[i] + " ";
		System.out.println(rjesenje + "]");
		System.out.println("Broj evaluacija: " + br);
	}

	private boolean check() {
		for (int i = 0; i < x0.length; i++) 
			if (this.dx[i] < vektor[i])
				return true;
		return false;
	}

	private double[] istrazi(double[] xp, double[] dx2) {
		double[] x = new double[xp.length];
		for (int i = 0; i < xp.length; i++) 
			x[i] = xp[i];
		for (int i = 0; i < x0.length; i++) {
			double p = f.calculate(x);
			x[i] += dx2[i];
			double no = f.calculate(x);
			if (no > p){
				x[i] -= 2 * dx2[i];
				no = f.calculate(x);
				if (no > p)
					x[i] = x[i] + dx2[i];
			}
		}
		return x;
	}
}
