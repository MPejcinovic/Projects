package hr.fer.zemris.apr.labos3;


import java.util.Arrays;
import java.util.Random;

import org.apache.commons.lang.ArrayUtils;

public class FloatingPointPrikaz implements Prikaz {

	private int velPop;
	private double mut;
	private int numEval;
	private int dg;
	private int gg;
	private int dim;
	private Function f;
	private double[][] populacija;
	Random r;
	
	public FloatingPointPrikaz(int velPop, double mut, int numEval, Function f, int dg, int gg, int dim){
		this.velPop = velPop;
		this.mut = mut;
		this.numEval = numEval;
		this.dg = dg;
		this.gg = gg;
		this.dim = dim;
		this.f = f;
		this.populacija = new double[velPop][dim];
		r = new Random();
		algorithm();
	}
	
	@Override
	public void algorithm() {
		int k = 3;
		double[] vrijednost = new double[this.velPop];
		double[][] pop = new double[k][this.dim];
		generirajPocetnuPopulaciju();
		
		vrijednost = evaluirajPopulaciju(this.populacija);
		
		sortiraj(vrijednost);
		
		for (int i = 0; i < this.numEval; i++) {
			int index = 0;
			int zamjena;
			double[][] nova = new double[2][this.dim];
			int[] rbrJed = new int[k];
			
			for (int j = 0; j < k; j++) {
				rbrJed[j] = velPop + 1;
			}
			
			// sluèajni odabir k jedinke
			for (int j = 0; j < k; j++) {
				int ind = (int) ((this.velPop)*this.r.nextDouble());
				if (Arrays.asList(ArrayUtils.toObject(rbrJed)).contains(ind))
					j--;
				else{
					rbrJed[j] = ind;
					pop[j] = this.populacija[ind];
				}
			}
			
			// najlošija jedinka
			double max = this.f.calculate(pop[0]);
			for (int j = 1; j < k; j++) {
				double value = this.f.calculate(pop[j]);
				if (value > max){
					max = value;
					index = j;
				}
			}
			zamjena = rbrJed[index];
			int br = 0;
			
			
			int[] index2 = new int[2];
			
			for (int j = 0; j < index2.length; j++) {
				index2[j] = k;
			}
			
			for (int j = 0; j < 2; j++) {
				int random = (int) Math.round(r.nextDouble() * (k-1));
				if (Arrays.asList(ArrayUtils.toObject(index2)).contains(random))
					j--;
				else{
					index2[j] = random;
					nova[j] = pop[random];
				}
			}
			//double[] novaJed = AritmetickoKrizanje(nova);
			double[] novaJed = HeuristickoKrizanje(nova);
			
			double in = r.nextDouble();
			if (in < this.mut){
				for (int j = 0; j < novaJed.length; j++)
					novaJed[j] += r.nextDouble();
			}
			
			
			for (int j = 0; j < novaJed.length; j++) {
				if (novaJed[j] > this.gg)
					novaJed[j] = this.gg;
				else if (novaJed[j] < this.dg)
					novaJed[j] = this.dg;
			}

			
			populacija[zamjena] = novaJed;
			
			nadjiNajbolju(i+1);
		}

		System.out.println();
		System.out.println("-------------Rezultat------------");
		System.out.println();
		nadjiNajbolju(0);
	}

	private void nadjiNajbolju(int a) {
		double min = this.f.calculate(this.populacija[0]);
		int ind = 0;
		for (int i = 1; i < this.velPop; i++) {
			double v = this.f.calculate(this.populacija[i]);
			if (v < min){
				min = v;
				ind = i;
			}
		}
		String zapis = "[ ";
		for (int i = 0; i < this.dim; i++) 
			zapis += this.populacija[ind][i] + " ";
		zapis += "]";
		if (a != 0)
			System.out.println(a + ". " + zapis + " " + min);
		else
			System.out.println(zapis + " " + min);
	}

	private double[] HeuristickoKrizanje(double[][] nova) {
		double[] novaJed = new double[this.dim];
		double rand = this.r.nextDouble();
		double f1 = this.f.calculate(nova[0]);
		double f2 = this.f.calculate(nova[1]);
		
		if (f1 > f2)
			for (int i = 0; i < this.dim; i++) 
				novaJed[i] = rand * (nova[1][i] - nova[0][i]) + nova[1][i];
		else
			for (int i = 0; i < novaJed.length; i++) 
				novaJed[i] = rand * (nova[0][i] - nova[1][i]) + nova[0][i];
		
		return novaJed;
	}

	
	private double[] AritmetickoKrizanje(double[][] nova) {
		double[] novaJed = new double[this.dim];
		double rand = this.r.nextDouble();
		for (int i = 0; i < this.dim; i++) {
			novaJed[i] = rand * nova[0][i] + (1 - rand) * nova[1][i];
		}
		return novaJed;
	}

	private double[] evaluirajPopulaciju(double[][] popul) {
		double[] FValue = new double[this.velPop];
		
		for (int i = 0; i < popul.length; i++) 
			FValue[i] = this.f.calculate(popul[i]);
		Arrays.sort(FValue);
		return FValue;
	}

	private void sortiraj(double[] fValue) {

		double[][] rez = new double[populacija.length][this.dim];
		for (int i = 0; i < populacija.length; i++) {
			for (int j = 0; j < populacija.length; j++) 
				if (this.f.calculate(populacija[i]) == fValue[j])
					for (int j2 = 0; j2 < this.dim; j2++) 
						rez[j][j2] = this.populacija[i][j2];
		}
		
		this.populacija = rez;
		
	}

	private void generirajPocetnuPopulaciju() {
		for (int i = 0; i < this.velPop; i++)
			for (int j = 0; j < this.dim; j++) 
				populacija[i][j] = this.dg + (this.gg - this.dg) * this.r.nextDouble();
	}

}
