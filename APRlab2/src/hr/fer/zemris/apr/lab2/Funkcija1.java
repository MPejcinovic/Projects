package hr.fer.zemris.apr.lab2;

public class Funkcija1 implements Funkcija {

	@Override
	public double calculate(double[] tocka) {
		if (tocka.length != 2)
			throw new IllegalArgumentException("You are to use two dimensional array for point!");
		return 100 * Math.pow((tocka[1] - Math.pow(tocka[0], 2)), 2) + Math.pow(1 - tocka[0], 2);
	}

}
