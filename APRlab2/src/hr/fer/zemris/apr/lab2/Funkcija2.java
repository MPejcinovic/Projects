package hr.fer.zemris.apr.lab2;

public class Funkcija2 implements Funkcija {

	@Override
	public double calculate(double[] tocka) {
		if (tocka.length != 2)
			throw new IllegalArgumentException("You are to use two dimensional array for point!");
		return Math.pow(tocka[0] - 4, 2) + 4 *  Math.pow(tocka[1] - 2, 2);
	}

}
