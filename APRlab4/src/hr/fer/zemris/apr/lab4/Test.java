package hr.fer.zemris.apr.lab4;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Scanner;

import apr.lab1.Matrica;

public class Test {

	/**
	 * @param args
	 * @throws IOException 
	 * @throws FileNotFoundException 
	 */
	public static void main(String[] args) throws FileNotFoundException, IOException {
		double T = 0.1;
		double[] interval = {0, 1};
		Scanner sc = new Scanner(System.in);
		Algoritam alg = null;
		
		Matrica x = new Matrica();
		x.fillMatrix("pocUvjet.txt");
		x.printMatrixOnScreen();
		System.out.println();
		
		Matrica a = new Matrica();
		a.fillMatrix("matrica1.txt");
		Matrica b = new Matrica();
		b.fillMatrix("matrica2.txt");
		
		System.out.println("1 - trapezni postupak; 2 - Runge-Kutta postupak;");
		int value = sc.nextInt();
		System.out.println("Nakon koliko iteracija zelite ispis vrijednosti?");
		int br = sc.nextInt();
		switch (value) {
		case 1:
			alg = new Trapez(T, interval, a, x, b, br);
			alg.algorithm();
			break;
		case 2:
			alg = new RungeKutta(T, interval, a, x, b, br);
			alg.algorithm();
			break;
		default:
			alg = new Trapez(T, interval, a, x, b, br);
			Algoritam alg2 = new RungeKutta(T, interval, a, x, b, br);
			break;
		}

	}

}
