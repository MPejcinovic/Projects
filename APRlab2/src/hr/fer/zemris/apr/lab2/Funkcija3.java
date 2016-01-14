package hr.fer.zemris.apr.lab2;

public class Funkcija3 implements Funkcija  {

	@Override
	public double calculate(double[] tocka) {
		double result = 0.0;
		for (int i = 0; i < tocka.length; i++) 
			result += Math.pow(tocka[i] - (i + 1), 2);
		return result;
	}

}
