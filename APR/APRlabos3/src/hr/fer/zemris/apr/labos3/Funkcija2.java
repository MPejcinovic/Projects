package hr.fer.zemris.apr.labos3;

public class Funkcija2 implements Function {

	@Override
	public double calculate(double[] tocka) {
		double result = 0.0;
		for (int i = 0; i < tocka.length; i++) 
			result += Math.pow(tocka[i] - (i + 1), 2);
		return result;
	}

}