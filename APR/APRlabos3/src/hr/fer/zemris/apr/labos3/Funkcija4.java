package hr.fer.zemris.apr.labos3;

public class Funkcija4 implements Function {

	@Override
	public double calculate(double[] tocka) {
		double sum = 0.0;
		for (int i = 0; i < tocka.length; i++) 
			sum += Math.pow(tocka[i], 2);
		return Math.pow(sum, 0.25) * (1 + Math.pow(Math.sin(50 * Math.pow(sum, 0.1)), 2));
	}

}