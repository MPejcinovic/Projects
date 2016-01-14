package hr.fer.zemris.apr.labos3;

public class Funkcija3 implements Function {

	@Override
	public double calculate(double[] tocka) {
		double sum = 0.0;
		for (int i = 0; i < tocka.length; i++) 
			sum += Math.pow(tocka[i], 2);
		return 0.5 + (Math.pow(Math.sin(Math.sqrt(sum)), 2) - 0.5) / Math.pow(1 + 0.001 * sum, 2);
	}

}