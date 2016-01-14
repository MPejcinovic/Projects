package apr.lab1;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.PrintStream;
import java.util.ArrayList;

public class Vektor extends Matrica{
	
	private int redak;
	private int stupac;
	public double[] matrica;
	
	public Vektor(int dim){
		matrica = new double[dim];
		this.redak = dim;
		this.stupac = 1;
	}
	
	public void fillMatrix(String naziv) throws FileNotFoundException{
		try (BufferedReader br = new BufferedReader(new FileReader(naziv))) {
			String line = br.readLine();
		    while (line != null) {
		    	String[] tmp = line.split("[\\s\\t]+");
		    	System.out.println(redak);
		    	if (tmp.length != redak)
		    		System.out.println("Vektor niste zadali na odgovarajuæi naèin!");
		    	for (int i = 0; i < tmp.length; i++) {
		    		this.matrica[i] = Double.parseDouble(tmp[i]);
		    	}
		        line = br.readLine();
		    }
		    
		} catch (Exception e) {
			throw new FileNotFoundException("File with given name does not exist!");
		}
	}

}
