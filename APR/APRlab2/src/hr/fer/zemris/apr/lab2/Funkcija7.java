package hr.fer.zemris.apr.lab2;
import hr.fer.zemris.apr.lab2.Funkcija;

public class Funkcija7 implements Funkcija {

	@Override
	public double calculate(double[] tocka) {
		if (tocka.length != 2)
			throw new IllegalArgumentException("You are to use two dimensional array for point!");
		return 100 * Math.pow(tocka[0], 2) + Math.pow(tocka[1] - 1, 2);
	}

}
