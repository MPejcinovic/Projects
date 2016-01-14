package hr.fer.zemris.apr.lab2;

public class CoordinateDescent {

	private double[] x0;
	private Funkcija f;
	final double GOLDEN_RATIO_COEF = 0.618;
	private double[] eps;
	
	public CoordinateDescent(Funkcija f, double[] x0, double[] vektor){
		this.f = f;
		this.x0 = x0;
		this.eps = vektor;
		coordinateDescent(x0);
	}
	
	private double[] findInterval(double step, int dim, double[] xs){
		int vel = xs.length;
		double[] interval = new double[2];
		double previous = 0.0;
		double current = 0.0;
		double[] kopija = new double[vel];
		double[] kopija2 = new double[vel];
		for (int i = 0; i < vel; i++){ 
			kopija[i] = xs[i];
			kopija2[i] = xs[i];
		}
		double f1 = f.calculate(xs);
		kopija[dim] += step;
		kopija2[dim] -= step;
		
		double f2 = f.calculate(kopija);
		
		if ((f.calculate(kopija2) > f.calculate(xs)) && (f.calculate(kopija) > f.calculate(xs))){
			interval[0] = xs[dim] - step;
			interval[1] = xs[dim] + step;
			return interval;
		}
		
		if (f2 < f1){
			previous = f2;
			while(true){
				step *= 2;
				kopija[dim] = xs[dim] + step;
				current = f.calculate(kopija);
				if (current > previous){
						interval[0] = xs[dim] + step/4; 
						interval[1] = xs[dim] + step;
						break;
				}else{
					previous = current;
					continue;
				}
			}
		}
		else{
			previous = f2;
			while(true){
				step *= 2;
				kopija[dim] = xs[dim] - step;
				current = f.calculate(kopija);
				if (current > previous){
						interval[1] = xs[dim] - step/4; 
						interval[0] = xs[dim] - step;
						break;
				}else{
					previous = current;
					continue;
				}
			}
		}
		return interval;
	}
	
	private void coordinateDescent(double[] x0){
		int vel = x0.length;
		int br = 0;
		double[] x = new double[vel];
		double[] xs = new double[vel];
		
		for (int i = 0; i < vel; i++) {
			xs[i] = x0[i];
		}
		
		do {
			br ++;
			for (int i = 0; i < vel; i++)
				xs[i] = x0[i];
			for (int i = 0; i < vel; i++) {
				double[] interval = findInterval(0.01, i, x0);
				interval = GoldenRatio(interval[0], interval[1], x0, i);
				x0[i] = 0.5 * (interval[0] + interval[1]);
			}
			boolean flag = true;
			for (int i = 0; i < vel; i++) {
				if (Math.abs(x0[i] - xs[i]) > eps[i])
					flag = false;
			}
			if (flag)
				break;
		} while (true);
		String zapis = "[ ";
		for (int i = 0; i < vel; i++) 
			zapis += Double.toString(x0[i]) + " ";
		System.out.println(zapis + "]");
		System.out.println("Broj evaluacija: " + br);
	}
	
	
	private double[] GoldenRatio(double a, double b, double[] kopija, int ind){
			
		int vel = kopija.length;
		double[] xs1 = new double[vel];
		double[] xs2 = new double[vel];
		
		for (int i = 0; i < vel; i++) 
			xs1[i] = xs2[i] = kopija[i];
		double c = b - GOLDEN_RATIO_COEF * (b - a);
		double d = a + GOLDEN_RATIO_COEF * (b - a);
		xs1[ind] = c;
		xs2[ind] = d;

		double fc = f.calculate(xs1);
		double fd = f.calculate(xs2);
			
		while((b - a) > eps[ind]){
			if (fc < fd) {
				b = d;
				d = c;
				c = b - GOLDEN_RATIO_COEF * (b - a);
				fd = fc;
				xs1[ind]= c;
				fc = f.calculate(xs1);
			}
			else{
				a = c;
				c = d;
				d = a + GOLDEN_RATIO_COEF * (b - a);
				xs2[ind] = d;
				fc = fd;
				fd = f.calculate(xs2);
			}
		}
		double[] inter = {a,b};
		return inter;
	}
}
