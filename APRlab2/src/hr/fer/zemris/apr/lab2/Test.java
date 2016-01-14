package hr.fer.zemris.apr.lab2;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class Test {

	@SuppressWarnings("resource")
	public static void main(String[] args) throws Exception{
		
		double[] tocka = null;
		Funkcija f;
		
		System.out.println("Koordinantno trazenje - 1; Hooke-Jeeves - 2; Box - 3");
		Scanner sc = new Scanner(System.in);
		int value = sc.nextInt();
		if (value == 1){
			double[] vektor = null;
			try {
				BufferedReader br = new BufferedReader(new FileReader("coord.txt"));
				String line = br.readLine();
				String[] par = line.split("[\\s\\t]+");
				vektor = new double[par.length];
				for (int i = 0; i < par.length; i++) 
					vektor[i] = Double.parseDouble(par[i]);
				line = br.readLine();
				par = line.split("[\\s\\t]+");
				tocka = new double[par.length];
				for (int i = 0; i < par.length; i++) 
					tocka[i] = Double.parseDouble(par[i]);
				br.close();
			} catch (FileNotFoundException e) {
				e.printStackTrace();
			}	
			System.out.println("Izaberite funkciju");
			f = izborFunkcije(sc);
			if (f instanceof Funkcija5){
				Random r = new Random();
				for (int i = 0; i < 2; i++)
					tocka[i] = -50 + r.nextDouble() * 100;
			}
			CoordinateDescent cd = new CoordinateDescent(f, tocka, vektor);
		}
		else if (value == 2){
			double[] vektorDx = null;
			double[] vektorEps = null;
			try {
				BufferedReader br = new BufferedReader(new FileReader("hookeJeeves.txt"));
				String line = br.readLine();
				String[] par = line.split("[\\s\\t]+");
				vektorDx = new double[par.length];
				for (int i = 0; i < par.length; i++) 
					vektorDx[i] = Double.parseDouble(par[i]);
				line = br.readLine();
				par = line.split("[\\s\\t]+");
				vektorEps = new double[par.length];
				for (int i = 0; i < par.length; i++) 
					vektorEps[i] = Double.parseDouble(par[i]);
				line = br.readLine();
				par = line.split("[\\s\\t]+");	
				tocka = new double[par.length];
				for (int i = 0; i < par.length; i++) 
					tocka[i] = Double.parseDouble(par[i]);
				br.close();
			} catch (FileNotFoundException e) {
				e.printStackTrace();
			}	
			System.out.println("Izaberite funkciju");
			f = izborFunkcije(sc);
			if (f instanceof Funkcija5){
				Random r = new Random();
				for (int i = 0; i < 2; i++)
					tocka[i] = -50 + r.nextDouble() * 100;
			}
			HookeJeevesAlgorithm hj = new HookeJeevesAlgorithm(f, tocka, vektorDx, vektorEps);
		}
		else if (value == 3){
			double eps = 0;
			double alfa = 0;
			try {
				BufferedReader br = new BufferedReader(new FileReader("box.txt"));
				String line = br.readLine();
				String[] par = line.split("[\\s\\t]+");
				eps = Double.parseDouble(par[0]);
				alfa = Double.parseDouble(par[1]); 
				line = br.readLine();
				par = line.split("[\\s\\t]+");	
				tocka = new double[par.length];
				for (int i = 0; i < par.length; i++) 
					tocka[i] = Double.parseDouble(par[i]);br.close();
			} catch (FileNotFoundException e) {
				e.printStackTrace();
			}
			System.out.println("Izaberite funkciju");
			f = izborFunkcije(sc);
			
			if (f instanceof Funkcija5){
				Random r = new Random();
				int br = 10000;
				for (int i = 0; i < 2; i++)
					tocka[i] = -50 + r.nextDouble() * 100;
				while(br > 0){
					br--;
					BoxAlgorithm ba = new BoxAlgorithm(eps, tocka, alfa, f);
				}
			}else{
				BoxAlgorithm ba = new BoxAlgorithm(eps, tocka, alfa, f);
			}
		}		else
			throw new IllegalArgumentException("Pogreska u odabiru algoritma; niste odabrali ni jednu od ponuðenih moguænosti!");
	}
	
	private static Funkcija izborFunkcije(Scanner sc){
		int value = sc.nextInt();
		if (value == 1)
			return new Funkcija1();
		else if (value == 2)
			return new Funkcija2();
		else if (value == 3)
			return new Funkcija3();
		else if (value == 4)
			return new Funkcija4();
		else if (value == 5)
			return new Funkcija5();
		else if (value == 6)
			return new Funkcija6();
		else if (value == 7)
			return new Funkcija7();
		return null;
	}
}
