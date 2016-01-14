package hr.fer.zemris.apr.lab2;

public class Funkcija5 implements Funkcija {

	@Override
	public double calculate(double[] tocka) {
		double sum = 0.0;
		for (int i = 0; i < tocka.length; i++) 
			sum += Math.pow(tocka[i], 2);
		return 0.5 + (Math.pow(Math.sin(sum), 2) - 0.5) / Math.pow(1 + 0.001 * sum, 2);
	}

}
