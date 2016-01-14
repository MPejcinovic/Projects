package hr.fer.zemris.apr.lab2;

public class Funkcija4 implements Funkcija {

	@Override
	public double calculate(double[] tocka) {
		if (tocka.length != 2)
			throw new IllegalArgumentException("You are to use two dimensional array for point!");
		return Math.abs((tocka[0] - tocka[1])*(tocka[0] + tocka[1])) + Math.sqrt(Math.pow(tocka[0], 2) + Math.pow(tocka[1], 2));
	}

}
