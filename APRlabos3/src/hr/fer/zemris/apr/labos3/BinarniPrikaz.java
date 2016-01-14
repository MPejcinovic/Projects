package hr.fer.zemris.apr.labos3;

import java.util.Arrays;
import java.util.Random;

import org.apache.commons.lang.ArrayUtils;

public class BinarniPrikaz implements Prikaz{
	private int velPop;
	private double mut;
	private int numEval;
	private int dim;
	private int dg;
	private int gg;
	private int preciznost;
	Function f;
	private String[][] populacija;
	private double[][] popul2;
	private int brBit;
	Random r;
	
	public BinarniPrikaz(int velPop, double mut, int numEval, Function f, int dim, int gg, int dg, int preciznost){
		this.velPop = velPop;
		this.mut = mut;
		this.numEval = numEval;
		this.dim = dim;
		this.dg = dg;
		this.gg = gg;
		this.preciznost = preciznost;
		this.f = f;
		this.populacija = new String[velPop][dim];
		this.popul2 = new double[velPop][dim];
		brBit = (int) Math.ceil(Math.log10(1 + (this.gg - this.dg) * Math.pow(10, this.preciznost)) / (Math.log10(2)));
		//System.out.println(brBit);
		r = new Random();
		algorithm();
	}
	
	@Override
	public void algorithm() {
		int k = 3;
		double[] vrijednost = new double[this.velPop];
		String[][] pop = new String[k][this.dim];
		double[] dijete = new double[this.dim];
		double[] rez = new double[this.dim];
		generirajPocetnuPopulaciju();
		
		vrijednost = evaluirajPopulaciju(this.popul2);
		
		for (int i = 0; i < this.numEval; i++) {
			int index = 0;
			int zamjena;
			String[][] nova = new String[2][this.dim];
			int[] rbrJed = new int[k];
			/*
			System.out.println();
			for (int j = 0; j < this.velPop; j++) {
				for (int j2 = 0; j2 < this.dim; j2++) {
					System.out.println(this.popul2[j][j2]);
				}
				System.out.println();
			}*/
			
			for (int j = 0; j < k; j++) {
				rbrJed[j] = velPop + 1;
			}
			
			// sluèajni odabir 3 jedinke
			for (int j = 0; j < k; j++) {
				int ind = (int) ((this.velPop)*this.r.nextDouble());
				//System.out.println("Ovo je index " + ind);
				if (contain(rbrJed, ind))
					j--;
				else{
					rbrJed[j] = ind;
					pop[j] = this.populacija[ind];
				}
				
			}
			//System.out.println();
			
			// najlošija jedinka
			double max = this.f.calculate(popul2[rbrJed[0]]);
			//System.out.println("Od 0: " + max);
			for (int j = 1; j < k; j++) {
				double value = this.f.calculate(popul2[rbrJed[j]]);
				//System.out.println("od " + j + ": " + value);
				if (value > max){
					max = value;
					index = j;
				}
			}
			zamjena = rbrJed[index];
			
			//System.out.println("Zamjena je " + rbrJed[index]);
			/*
			int br = 0;
			for (int j = 0; j < 3; j++) {
				if (j == index)
					continue;
				else{
					for (int j2 = 0; j2 < this.dim; j2++) {
						nova[br][j2] = pop[j][j2];
					}
					br ++;
				}
			}
			*/
			
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
			//String[] novaJed = SinglePointCrossover(nova);
			
			String[] novaJed = UniformnoKrizanje(nova);
			
			double sl = r.nextDouble();
			if (sl < this.mut){
				for (int j = 0; j < this.dim; j++) {
					String zapis = "";
					for (int j2 = 0; j2 < brBit; j2++) {
						zapis += String.valueOf(1 - Integer.parseInt(novaJed[j].substring(j2, j2 + 1), 2));
					}
					novaJed[j] = zapis;
				}
			}

			for (int j = 0; j < this.dim; j++) {
				dijete[j] = this.dg + (Integer.parseInt(novaJed[j], 2) * (this.gg - this.dg) / (Math.pow(2, brBit) - 1));
			}
			
			/*
			for (int j = 0; j < this.dim; j++) {
				System.out.println(dijete[j]);
			}
			*/
			
			for (int j = 0; j < this.dim; j++) {
				populacija[zamjena][j] = novaJed[j];
				popul2[zamjena][j] = dijete[j];
			}
			
			nadjiNajbolju(i+1);
		}
		System.out.println();
		System.out.println("-------------Rezultat------------");
		System.out.println();
		nadjiNajbolju(0);
			
	}


	private void nadjiNajbolju(int a) {
		double min = 100000000000.0;
		int ind = 0;
		double[] decim = new double[this.dim];
		for (int i = 0; i < this.velPop; i++) {
			for (int j = 0; j < this.dim; j++) {
				decim[j] = this.dg + (Integer.parseInt(this.populacija[i][j], 2) * (this.gg - this.dg) / (Math.pow(2, brBit) - 1));
			}
			double value = this.f.calculate(decim);
			if (value < min){
				min = value;
				ind = i;
			}
		}
		String zapis = "[ ";
		//System.out.println("Najbolja jedinka je: ");
		for (int i = 0; i < this.dim; i++)
			zapis += this.populacija[ind][i] + " ";
		zapis += "]";
			//System.out.println(this.populacija[ind][i]);
		if (a != 0)
			System.out.println(a + ". " + zapis + " " + f.calculate(this.popul2[ind]));
		else
			System.out.println(zapis + " " + f.calculate(this.popul2[ind]));
		//System.out.println(f.calculate(this.popul2[ind]));
		
		System.out.println();
		for (int i = 0; i < this.dim; i++) {
			System.out.println(this.dg + (Integer.parseInt(this.populacija[ind][i], 2) * (this.gg - this.dg) / (Math.pow(2, brBit) - 1)));
		System.out.println();
		}
	}

	private boolean contain(int[] polje, int value){
		for (int k : polje) 
			if (k == value)
				return true;
		return false;
	}
	
	private String[] UniformnoKrizanje(String[][] nova) {
		String p = "";
		String s = "";
		double R = this.dg + (this.gg - this.dg) * r.nextDouble();
		String ran = String.format("%21s", Integer.toBinaryString((int)Math.round(((R- this.dg) * (Math.pow(2, brBit) - 1))/(this.gg - this.dg)))).replace(' ', '0');
		String[] povratak = new String[this.dim];
		for (int i = 0; i < povratak.length; i++) {
			povratak[i] = "";
		}
		for (int i = 0; i < this.dim; i++) {
			for (int j = 0; j < this.brBit; j++) {
				p = nova[0][i].substring(j,j+1);
				s = nova[1][i].substring(j,j+1);
				if (p.equals(s)){
					povratak[i] += p;
				}
				else{
					povratak[i] += ran.substring(j,j+1);
				}
			}
		}
		return povratak;
	}

	private String[] SinglePointCrossover(String[][] nova) {
		String[][] rez = new String[2][this.dim];
		double[][] dec = new double[2][this.dim];
		
		int tocka = (int) Math.round(r.nextDouble() * brBit);
		for (int j = 0; j < this.dim; j++) {
			rez[0][j] = nova[0][j].substring(0,tocka) + nova[1][j].substring(tocka);
			rez[1][j] = nova[1][j].substring(0,tocka) + nova[0][j].substring(tocka);
		}
		
		for (int j = 0; j < this.dim; j++) {
			dec[0][j] = this.dg + (Integer.parseInt(rez[0][j], 2) * (this.gg - this.dg) / (Math.pow(2, brBit) - 1));
			dec[1][j] = this.dg + (Integer.parseInt(rez[1][j], 2) * (this.gg - this.dg) / (Math.pow(2, brBit) - 1));
		}
		
		double f1 = this.f.calculate(dec[0]);
		double f2 = this.f.calculate(dec[1]);
		
		if (f1 < f2)
			return rez[0];
		else
			return rez[1];
		
	}

	private double[] evaluirajPopulaciju(double[][] popul22) {	
		double[] FValue = new double[this.velPop];
		//System.out.println();
		for (int i = 0; i < popul22.length; i++){ 
			FValue[i] = this.f.calculate(popul22[i]);
			//System.out.println(FValue[i]);
		}
		return FValue;
	}

	/*
	private void generirajPocetnuPopulaciju() {
		double pop = 0.0;
		for (int i = 0; i < this.velPop; i++)
			for (int j = 0; j < this.dim; j++){
				pop = this.dg + (this.gg - this.dg) * this.r.nextDouble();
				this.populacija[i][j] = String.format("%15s", Integer.toBinaryString((int)Math.round(((pop - this.dg) * (Math.pow(2, brBit) - 1))/(this.gg - this.dg)))).replace(' ', '0');
				this.popul2[i][j] = pop;
			}
	}*/

	private void generirajPocetnuPopulaciju() {
		for (int i = 0; i < this.velPop; i++) {
			for (int j = 0; j < this.dim; j++) {
				String zapis = "";
				for (int j2 = 0; j2 < this.brBit; j2++) 
					if (r.nextDouble() <= 0.5)
						zapis += "0";
					else
						zapis += "1";
				this.populacija[i][j] = zapis;
				this.popul2[i][j] = this.dg + (Integer.parseInt(zapis, 2) * (this.gg - this.dg) / (Math.pow(2, brBit) - 1));
			}
		}
	}
}

