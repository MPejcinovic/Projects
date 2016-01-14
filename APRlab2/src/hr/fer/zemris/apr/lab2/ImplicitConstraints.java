package hr.fer.zemris.apr.lab2;

public class ImplicitConstraints implements Constraints {

	public ImplicitConstraints(){
		
	}
	
	@Override
	public boolean check(double[] x0) {
		return (x0[1] - x0[0] >= 0) && (x0[0] <= 2);
	}

}
