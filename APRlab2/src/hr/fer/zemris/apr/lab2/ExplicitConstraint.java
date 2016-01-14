package hr.fer.zemris.apr.lab2;

public class ExplicitConstraint implements Constraints{

	private double dg;
	private double gg;
	
	public ExplicitConstraint(double d, double g){
		setDG(d);
		setGG(g);
	}
	
	public void setDG(double d){
		this.dg = d;
	}
	
	public double getDG(){
		return this.dg;
	}
	
	public void setGG(double g){
		this.gg = g;
	}
	
	public double getGG(){
		return this.gg;
	}
	
	@Override
	public boolean check(double[] x0) {
		for (int i = 0; i < x0.length; i++)
			if (x0[i] < dg  || x0[i] > gg)
				return false;
		return true;
	}

}
