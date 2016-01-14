package hr.fer.zemris.apr.labos3;

import java.util.Scanner;

public class Test {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(System.in);
		@SuppressWarnings("unused")
		Prikaz p = null;
		Function f = null;
		int dim = 0;
		
		System.out.println("Koju funkciju zelite evaluirati?");
		int fja = Integer.parseInt(sc.nextLine());
		switch (fja) {
		case 1:
			f = new Funkcija1();
			dim = 2;
			break;
		case 2:
			f = new Funkcija2();
			dim = 3;
			break;
		case 3:
			f = new Funkcija3();
			dim = 10;
			break;
		case 4:
			f = new Funkcija4();
			dim = 6;
			break;
		default:
			break;
		}
		System.out.println("Unesite zeljenu velicinu populacije: ");
		int velPop = Integer.parseInt(sc.nextLine());
		System.out.println("Unesite zeljenu vjerojatnost mutacije: ");
		double mut = Double.parseDouble(sc.nextLine());
		System.out.println("Unesite zeljeni broj evaluacija: ");
		int numEval = Integer.parseInt(sc.nextLine());
		System.out.println("Za binarni prikaz odaberite 1, za prikaz s pomicnom tockom odaberite 2");
		int choice = sc.nextInt(); 
		if (choice == 1)
			p = new BinarniPrikaz(velPop, mut, numEval, f, dim, 150, -50, 4);
		else if (choice == 2)
			p = new FloatingPointPrikaz(velPop, mut, numEval, f, -50, 150, dim);
		else
			throw new IllegalArgumentException("Niste unijeli odgovarajuci izbor!");
	}

}
