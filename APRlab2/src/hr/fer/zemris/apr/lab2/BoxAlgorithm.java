package hr.fer.zemris.apr.lab2;

import java.util.Random;

public class BoxAlgorithm {

	private double a;
	private double[] x0;
	private double eps;
	private Funkcija f;
	ExplicitConstraint c1;
	ImplicitConstraints c2;
	
	public BoxAlgorithm(double eps, double[] x0, double a, Funkcija f) throws Exception{
		this.a = a;
		this.eps = eps;
		this.x0 = x0;
		this.f = f;
		this.c1 = new ExplicitConstraint(-100, 100);
		this.c2 = new ImplicitConstraints();
		algorithm();
	}
	
	private void algorithm() throws Exception{
		Random e = new Random();
		int br = 0;
		int vel = this.x0.length;
		
		if (!provjeriOgranicenja())
			throw new Exception("Tocka ne zadovoljava ogranicenja!");
		
		double[] xc = new double[vel];
		double[] xr = new double[vel];
		double[][] rand = new double[2*vel][vel];

		for (int i = 0; i < vel; i++) 
			xc[i] = this.x0[i];
		
		for (int t = 0; t < 2 * vel; t++) {
			for (int i = 0; i < vel; i++) 
				rand[t][i] = e.nextDouble() * (100 + 100)  - 100;
			while(!implConstraint(rand[t]))
				for (int i = 0; i < vel; i++) 
					rand[t][i] = 0.5 * (rand[t][i] + xc[i]);
			xc = izracunCentroida(rand); 
		}
		
		boolean flag = false;
		while(!flag){
			br ++;
			//System.out.println("Racunam");
			int worst = nadjiNajlosiju(rand);
			int scndWorst = nadjiDruguNajlosiju(rand, worst);
			xc = izracunCentroidaBezNajlosije(rand, worst);
			
			for (int i = 0; i < vel; i++)
				xr[i] = (1 + this.a) * xc[i] - this.a * rand[worst][i];
			for (int i = 0; i < vel; i++) {
				if (xr[i] < this.c1.getDG())
					xr[i] = this.c1.getDG();
				else{
					if(xr[i] > this.c1.getGG())
						xr[i] = this.c1.getGG();
				}
			}
			while(!implConstraint(xr)){
				//System.out.println("Pomicem prema centroidu");
				for (int i = 0; i < vel; i++) 
					xr[i] = 0.5 * (xr[i] + xc[i]);
			}
			
			if (this.f.calculate(xr) > this.f.calculate(rand[scndWorst]))
				for (int i = 0; i < vel; i++) 
					xr[i] = 0.5 * (xr[i] + xc[i]);

			for (int i = 0; i < vel; i++)
				rand[worst][i] = xr[i];
			for (int i = 0; i < vel; i++) {
				if (Math.abs(rand[worst][i] - xc[i]) < eps)
					flag = true;
			}
		}
		System.out.println("Nasao");
		for (int i = 0; i < xc.length; i++) {
			System.out.println(xc[i]);
		}
		System.out.println("Broj evaluacija: " + br);
	}
	
	

	private int nadjiDruguNajlosiju(double[][] rand, int worst) {
		double max;
		int indeks;
		int start;
		if (worst != 0){
			max = this.f.calculate(rand[0]);
			indeks = 0;
		}
		else{
			max = this.f.calculate(rand[1]);
			indeks = 1;
		}
		
		for (int i = 0; i < rand.length; i++) {
			if (i != worst){
				double value = this.f.calculate(rand[i]);
				if (value > max){
					indeks = i;
					max = value; 
			    }	
			}
		}
		return indeks;
	}

	private int nadjiNajlosiju(double[][] rand) {
		double max = this.f.calculate(rand[0]);
		int indeks = 0;
		for (int i = 1; i < rand.length; i++) {
			double value = this.f.calculate(rand[i]);
			if (value > max){
				indeks = i;
				max = value; 
			}	
		}
		return indeks;
	}

	private double[] izracunCentroida(double[][] rand) {
		double[] centroid = new double[rand[0].length];
		for (int i = 0; i < rand.length; i++) {
			for (int j = 0; j < rand[0].length; j++) 
				centroid[j] += rand[i][j];
		}
		for (int i = 0; i < centroid.length; i++)
			centroid[i] /= rand.length;
		return centroid;
	}

	private double[] izracunCentroidaBezNajlosije(double[][] rand, int worst) {
		double[] centroid = new double[rand[0].length];
		for (int i = 0; i < rand.length; i++) {
			if (i != worst){ 
				for (int j = 0; j < rand[0].length; j++) 
					centroid[j]  += rand[i][j];
			}
		}
		for (int i = 0; i < centroid.length; i++) {
			centroid[i] /= (rand.length - 1);
		}
		return centroid;
	}

	private boolean implConstraint(double[] rand) {
		return this.c2.check(rand);
	}

	private boolean provjeriOgranicenja() {
		return this.c1.check(x0) && this.c2.check(x0);
	}
	
}
