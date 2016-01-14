package apr.lab1;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

/**
 * Class that implements method for matrices; it includes methods that implement
 * joining one matrix to another, method that reads text file in order to fill 
 * matrix with its content, method that prints matrix in either a file or on screen,
 * setter and getter method for one element of matrix, methods for adding, 
 * subtracting, multiplication and transposing matrices, method that implements
 * += and -= operator, method for scalar multiplication of matrix, method
 * for comparing matrices and methods for LU / LUP decomposition 
 * @author Matea Pejèinoviæ
 * @version 1.0
 */
public class Matrica {
	
	private int redak;
	private int stupac;
	private List<List<Double>> matrica;
	
	/**
	 * Constructor for class Matrica that creates matrix with dimensions that are gotten as input values 
	 * @param redak (int) number of rows
	 * @param stupac (int) number of columns
	 */
	public Matrica(){
		this.stupac = this.redak = 0;
		this.setMatrica(new ArrayList<List<Double>>());
	}
	
	/**
	 * Setter for rows
	 * @param dim (int) number of rows that matrix should contain
	 */
	public void setRow(int dim){
		this.redak = dim;
	}
	
	/**
	 * Getter for rows
	 * @return (int) number of rows in matrix
	 */
	public int getRow(){
		return this.redak;
	}
	
	/**
	 * Setter for columns
	 * @param dim (int) number of columns that matrix should contain 
	 */
	
	public void setCol(int dim){
		this.stupac = dim;
	}
	
	/**
	 * Getter for columns
	 * @return (int) number of columns in matrix
	 */
	public int getCol(){
		return this.stupac;
	}
	
	/**
	 * Getter for column
	 * @param index (int) index of column in matrix
	 * @return (double[]) vector that represent column with given index 
	 */
	/*
	public double[] getStupac(int index){
		double[] tmp = new double[this.redak];
		for (int i = 0; i < this.redak; i++) {
			tmp[i] = this.matrica[i][index];
		}
		return tmp;
	}*/
	
	/**
	 * Getter for row
	 * @param index (int) index of row in matrix
	 * @return (double[]) vector that represent row with given index
	 */
	/*
	public double[] getRedak(int index){
		double[] tmp = new double[this.stupac];
		for (int i = 0; i < this.stupac; i++) {
			tmp[i] = this.matrica[index][i];
		}
		return tmp;
	}
	*/
	/**
	 * Method for filling matrix using file given as input
	 * @param naziv (String) name of the file that contains matrix written in .txt
	 * @throws FileNotFoundException if @naziv is not found
	 * @throws IOException
	 */
	public void fillMatrix(String naziv) throws FileNotFoundException, IOException{
		 try(BufferedReader br = new BufferedReader(new FileReader(naziv))) {
		        String line = br.readLine();
		        int red = 0;
		        while (line != null) {
		            String[] tmp = line.split("[\\s\\t]+");
		            if (this.stupac == 0)
		            	setCol(tmp.length);
		            this.getMatrica().add(new ArrayList<Double>());
		            for (int i = 0; i < this.stupac; i++) {
		        		this.getMatrica().get(red).add(Double.parseDouble(tmp[i]));
					}
		        	red++;
		        	line = br.readLine();
		        }
		        setRow(red);
		   }
	}
	
	/**
	 * Method that prints out the matrix
	 */
	public void printMatrixOnScreen(){
		 for (int i = 0; i < this.redak; i++) {
		        for (int j = 0; j < this.stupac; j++) {
					System.out.print(this.getElement(i,j) + " ");
				}
		       	System.out.println();	
		 }
	}
	
	/**
	 * Method that prints matrix in a file named izlaz.txt
	 */
	public void printMatrixInFile(){
		try{
			PrintStream fw = new PrintStream(new File("izlaz.txt"));
			for (int i = 0; i < this.redak; i++) {
				for (int j = 0; j < this.stupac; j++) {
					fw.print(this.getMatrica().get(i).get(j).toString() + " ");
				}
				fw.println();
			}
			fw.close();
		}catch(Exception ex){
			ex.printStackTrace();
		}
	}
	
	/**
	 * Method for copying matrix
	 * @param B (Matrica) Used for coping matrix A
	 * @return (Matrica) matrix B that is the same as this
	 */
	public void pridruzi(Matrica B){
		B.redak = this.redak;
		B.stupac = this.stupac;
		
		Collections.copy(B.getMatrica(), this.getMatrica());
		
	}
	
	/**
	 * Method that sets element of matrix to given value
	 * @param x (int) index of the row of element that is to be changed
	 * @param y (int) index of the column of element that is to be changed
	 * @param value (double) new value of the element of matrix with indexes @x and @y
	 * @throws IllegalArgumentException if arguments are not in appropriate range
	 */
	public void setElement(int x, int y, double value){
		if (x > this.redak || x < 0 || y > this.stupac || y < 0 )
			throw new IllegalArgumentException("Zadani argumenti ne odgovaraju dimenzijama matrice");
		this.getMatrica().get(x).set(y, value);
	}
	
	/**
	 * Method that get element of matrix using its indexes
	 * @param x (int) index of the row that belongs to element
	 * @param y (int) index of the column that belongs to element 
	 * @return (double) matrix[x][y]
	 * @throws IllegalArgumentException if indexes are not in appropriate range
	 */
	public double getElement(int x, int y){
		if (x > this.redak || x < 0 || y > this.stupac || y < 0 )
			throw new IllegalArgumentException("Zadani argumenti ne odgovaraju dimenzijama matrice");
		return this.getMatrica().get(x).get(y);
	} 
	
	/**
	 * Method for adding one matrix to another one
	 * @param A (Matrica) Matrix for addition
	 * @param B (Matrica) Matrix for addition
	 * @return (Matrica) C as a result of addition
	 */
	public static Matrica add(Matrica A, Matrica B){
		if (A.getCol() != B.getCol() || A.getRow() != B.getRow()){
			throw new IllegalArgumentException("Dimensions of matrices do not match!");
		}
		Matrica C = new Matrica();
		C.redak = A.redak;
		C.stupac = A.stupac;
		for (int i = 0; i < A.redak; i++) {
			C.getMatrica().add(new ArrayList<Double>());
			for (int j = 0; j < A.stupac; j++) {
				C.getMatrica().get(i).add(j, A.getElement(i, j) + B.getElement(i, j));
			}
		}
		return C;
	}
	
	/**
	 * Method for subtraction of two matrices
	 * @param A (Matrica) Matrix for subtraction
	 * @param B (Matrica) Matrix for subtraction
	 * @return (Matrica) C as a result of subtraction
	 */
	public static Matrica subtract(Matrica A, Matrica B){
		if (A.getCol() != B.getCol() || A.getRow() != B.getRow()){
			throw new IllegalArgumentException("Dimensions of matrices do not match!");
		}
		Matrica C = new Matrica();
		C.redak = A.redak;
		C.stupac = A.stupac;
		for (int i = 0; i < A.redak; i++) {
			C.getMatrica().add(new ArrayList<Double>());
			for (int j = 0; j < A.stupac; j++) {
				C.getMatrica().get(i).add(j, A.getElement(i, j) - B.getElement(i, j));
			}
		}
		return C;
	}
	
	/**
	 * Method used for multiplication of two matrices
	 * @param A (Matrica) Matrix for multiplication
	 * @param B (Matrica) Matrix for multiplication
	 * @return (Matrica) C as a result of multiplication
	 */
	public static Matrica multiplicate(Matrica A, Matrica B){
		if (A.getCol() != B.getRow()){
			throw new IllegalArgumentException("Cannot multiplicate... Dimensions of matrices do not match!");
		}
		Matrica C = new Matrica();
		C.setRow(A.getRow());
		C.setCol(B.getCol());
		
		for (int i = 0; i < C.getRow(); i++) {
			C.getMatrica().add(new ArrayList<Double>());
			for (int j = 0; j < C.getCol(); j++) {
				C.getMatrica().get(i).add(j, 0.0);
			}
		}
		
		for (int i = 0; i < A.getRow(); i++) { 
            for (int j = 0; j < B.getCol(); j++) { 
                for (int k = 0; k < A.getCol(); k++) { 
                    C.setElement(i, j, C.getElement(i, j) + A.getElement(i,k) * B.getElement(k, j));
                }
            }
        }
		return C;
	}
	
	/**
	 * Method for transposing matrix
	 */
	public void transpose(){
		List<List<Double>> tmp = new ArrayList<List<Double>>();
		for (int i = 0; i < this.stupac; i++) {
			tmp.add(new ArrayList<Double>());
			for (int j = 0; j < this.redak; j++) {
				tmp.get(i).add(this.getElement(j, i));
			}
		}
		int temp = this.getCol();
		this.setCol(this.getRow());
		this.setRow(temp);
		this.setMatrica(tmp);
	}
	
	
	/**
	 * Method for multiplication of scalar and matrix
	 * @param value (double) value that is being used for multiplication
	 */
	public static Matrica scalarMultiplication(Matrica a, double value){
		for (int i = 0; i < a.redak; i++) {
			for (int j = 0; j < a.stupac; j++) {
				//this.getMatrica().get(i).set(j, value * this.getElement(i, j));
				a.getMatrica().get(i).set(j, value * a.getElement(i, j));
			}
		}
		return a;
	}
	
	/**
	 * Method that implements += operator
	 * @param inValue (double) value that is on the left side of operator +=
	 * @param addValue (double) value that is being added to @inValue
	 * @return (double) result of += operator
	 */
	public double plusOperator(double inValue, double addValue){
		return inValue + addValue;
	}
	
	/**
	 * Method that implements -= operator
	 * @param inValue (double) value that is on the left side of operator -=
	 * @param addValue (double) value that is being added to @inValue
	 * @return (double) result of -= operator
	 */
	public double minusOperator(double inValue, double addValue){
		return inValue - addValue;
	}

	/**
	 * Method for comparing two matrices
	 * @param A (Matrica) first matrix for comparison
	 * @param B (Matrica) second matrix for comparison
	 * @return true if matrices are equal, otherwise false
	 */
	public boolean compareMatrices(Matrica A, Matrica B){
		if ((A.getRow() != B.getRow() || A.getCol() != B.getCol()) || ((A.getMatrica() == null && B.getMatrica()!= null) || (A.getMatrica() != null && B.getMatrica()== null))){
	        return false;
	    }
	    if (A.getMatrica() == null && B.getMatrica() == null) return true;
	    for (int i = 0; i < A.getRow(); i++) {
			for (int j = 0; j < A.getCol(); j++) {
				if (Math.abs(A.getElement(i, j) - B.getElement(i, j)) < 0.0000001)
					return false;
			}
		}
	    return true;
	}
	
	/**
	 * Method for LU decomposition of matrix
	 */
	public void LUDekompozicija(){
		int n = this.getRow();	
		for (int i = 0; i < n-1; i++) {
			if (Math.abs(this.getElement(i, i)) < 0.000001){
					System.out.println("Sustav nema rješenja");
					System.exit(0);
			}
			for (int j = i+1; j < n; j++) {
				
				this.setElement(j, i, this.getElement(j, i) / this.getElement(i, i));
				for (int k = i+1; k < n; k++) {
					this.setElement(j, k, this.getElement(j, k) - this.getElement(j, i) * this.getElement(i, k));
				}
			}
		}
		System.out.println("LU dekompozicija: ");
		this.printMatrixOnScreen();
	}
	
	/**
	 * Method for LUP decomposition of matrix
	 * @param ind (int[]) field that will take positions of rows after LUP decomposition
	 */
	public void LUPDekompozicija(int[] ind){

		int n = this.getRow();
		
		for (int i = 0; i < n-1; i++) {
			int pivot = i;
			for (int j = i+1; j < n; j++) {
				if (Math.abs(this.getElement(ind[j], i)) > Math.abs(this.getElement(ind[pivot], i)))
						pivot = j;
			}
			int tmp = ind[pivot];
			ind[pivot] = ind[i];
			ind[i] = tmp;
			if (Math.abs(this.getElement(ind[i], i)) < 0.000001){
				System.out.println("Sustav nema rješenja");
				System.exit(0);
			}
			for (int j = i+1; j < n; j++) {
				this.getMatrica().get(ind[j]).set(i, this.getElement(ind[j], i)/this.getElement(ind[i], i));
				for (int k = i+1; k < n; k++) {
					this.getMatrica().get(ind[j]).set(k, this.getElement(ind[j], k) - this.getElement(ind[j], i) * this.getElement(ind[i], k));
				}
			}
		}

		//System.out.println("LUP dekompozicija: ");
		//this.printMatrixOnScreen();
	}
	
	/**
	 * Method that implements forward substitution
	 * @param b (Matrica) Vector on the right side of equation 
	 * @param ind (int[]) field that contains information for permutation matrix
	 */
	public Matrica supstitucijaUnaprijed(Matrica b, int[] ind){
		int n = this.getRow();
		
		Matrica PermutacijskaMatrica = new Matrica();
		PermutacijskaMatrica.setCol(n);
		PermutacijskaMatrica.setRow(n);
		for (int i = 0; i < n; i++) {
			PermutacijskaMatrica.getMatrica().add(new ArrayList<Double>());
			for (int j = 0; j < n; j++) {
				int el = ind[i];
				if (j == el)
					PermutacijskaMatrica.getMatrica().get(i).add(1.0);
			else
				PermutacijskaMatrica.getMatrica().get(i).add(0.0);
			}
		}
		//System.out.println();
		Matrica m = new Matrica();
		m.setCol(b.getRow());
		m.setRow(b.getCol());
		for (int i = 0; i < m.getRow(); i++) {
			m.getMatrica().add(new ArrayList<Double>());
			for (int j = 0; j < m.getCol(); j++) {
				m.getMatrica().get(i).add(b.getElement(j, i));
			}
		}
		
		b = multiplicate(PermutacijskaMatrica, m);
		m = multiplicate(PermutacijskaMatrica, this);
		for (int i = 0; i < n - 1; i++) {
			for (int j =  i+1; j < n; j++) {
				b.getMatrica().get(j).set(0, b.getElement(j, 0) - m.getElement(j, i) * b.getElement(i, 0) );
			}
		}
		//System.out.println();
		//System.out.println("Supstitucija Unaprijed");
		//b.printMatrixOnScreen();
		m.pridruzi(this);
		//System.out.println("b u sups unaprijed");
		//b.printMatrixOnScreen();
		Matrica k = this.supstitucijaUnatrag(b);
		return k;
	}
	
	/**
	 * Method that implements back substitution
	 * @param b (Matrica) Vector on the right side of equation
	 */
	public Matrica supstitucijaUnatrag(Matrica b){
		int n = this.getRow();
		for (int i = n-1; i >= 0; i--) {
			if (Math.abs(this.getElement(i, i)) < 0.000000001){
				System.out.println("Dijeljenje s nulom nije dozvoljeno!");
				System.exit(0);
			}
			b.getMatrica().get(i).set(0, b.getElement(i, 0) / this.getElement(i, i));
			for (int j = 0; j <= i-1; j++) {
				b.getMatrica().get(j).set(0, b.getElement(j, 0) - this.getElement(j, i) * b.getElement(i, 0));
			}
		}	
		//System.out.println("this na kraju supstitucije unatrag");
		//this.printMatrixOnScreen();
		//System.out.println();
		//System.out.println("b koji je rezultat");
		//b.printMatrixOnScreen();
		//System.out.println();
		for (int i = 0; i < b.getRow(); i++) {
			for (int j = 0; j < b.getCol(); j++) {
				double el = b.getElement(i, j);
				double ro = Math.round(el);
				if (Math.abs(ro - el) < 0.000001)
					b.getMatrica().get(i).set(j, ro);
			}
		}
		
		//System.out.println();
		//System.out.println("Rezultat: ");
		//b.printMatrixOnScreen();
		return b;
	}
	
	public static Matrica vratiJedinicnu(int row, int col){
		Matrica I = new Matrica();
		I.setRow(row);
		I.setCol(col);
		for (int j = 0; j < I.getRow(); j++) {
			I.getMatrica().add(new ArrayList<Double>());
			for (int j2 = 0; j2 < I.getCol(); j2++) {
				if (j == j2)
					I.getMatrica().get(j).add(j2, 1.0);
				else 
					I.getMatrica().get(j).add(j2, 0.0);
			}
		}
		return I;
	}

	public List<List<Double>> getMatrica() {
		return this.matrica;
	}

	public void setMatrica(List<List<Double>> matrica) {
		this.matrica = matrica;
	}

	public Matrica izracunajInverz() {
		Matrica I = null;
		int brRed = this.getRow();
		int brSt = this.getCol();
		
		if (brRed != brSt)
			throw new IllegalStateException("This is not square matrix!");
		else if (this.izracunajDeterminantu() == 0)
			throw new IllegalStateException("This is a singular matrix which is noninvertible!");
		else{
			int[] ind = new int[brRed];
			for (int i = 0; i < brRed; i++) {
				ind[i] = i;
			}
			//System.out.println("poslano");
			//this.printMatrixOnScreen();
			//Matrica rez = new Matrica();
			this.LUPDekompozicija(ind);
			//System.out.println("Ovo je originalna matrica");
			//this.printMatrixOnScreen();
			Matrica rez = this;
			I = new Matrica();
			I.setCol(brSt);
			I.setRow(brRed);
			for (int i = 0; i < brRed; i++) {
				I.getMatrica().add(new ArrayList<Double>());
				for (int j = 0; j < brSt; j++)
					I.getMatrica().get(i).add(j, 0.0);
			}
			//I.printMatrixOnScreen();
			for (int i = 0; i < brSt; i++) {
				Matrica pr = new Matrica();
				pr.inicijaliziraj(this.getRow(), this.getCol());
				for (int j = 0; j < this.getRow(); j++) {
					for (int j2 = 0; j2 < this.getCol(); j2++) {
						pr.getMatrica().get(j).set(j2, this.getElement(j, j2));
					}
				}
				Matrica b = new Matrica();
				b.setCol(brRed);
				b.setRow(1);
				b.getMatrica().add(new ArrayList<Double>());
				for (int j = 0; j < brSt; j++) {
					if (i == j)
						b.getMatrica().get(0).add(j, 1.0);
					else
						b.getMatrica().get(0).add(j, 0.0);
				}
				//this.printMatrixOnScreen();
				Matrica k = new Matrica();
				k.setRow(brRed);
				k.setCol(1);
				k = pr.supstitucijaUnaprijed(b, ind);
				//System.out.println("Ovu saljem");
				//pr.printMatrixOnScreen();
				//System.out.println("k");
				//k.printMatrixOnScreen();
				for (int j = 0; j < brRed; j++){ 
					I.setElement(j, i, k.getElement(j, 0));
				}
			}
		}
		//System.out.println("inverz u fji");
		//I.printMatrixOnScreen();
		return I;
	}

	public double izracunajDeterminantu() {
		    double sum = 0;
		    int s = 0;
		    int red = this.getRow();
		    int st = this.getCol();
		    
		    if(red == 1 && st == 1)
		    	return this.getElement(0, 0);
		    if (red == 2 && st == 2) 
		    	return this.getElement(0, 0) * this.getElement(1, 1) - this.getElement(0, 1) * this.getElement(1, 0);
		    			
		    for(int i = 0 ; i < red; i++){ 
		    	Matrica manja = new Matrica();
		    	manja.setRow(red - 1);
		    	manja.setCol(st - 1);
		    	
		    	for(int a = 1; a < red;a++){
					manja.getMatrica().add(new ArrayList<Double>());
		    		for(int b = 0 ; b < st;b++)
		    			if(b < i)
		    				manja.getMatrica().get(a - 1).add(b, this.getElement(a, b));
		    			else if(b>i)
		    				manja.getMatrica().get(a -1).add(b - 1, this.getElement(a, b));
		      }
		      //System.out.println();
		      if(i%2==0)
		    	  s = 1;
		      else
		    	  s = -1;
		      sum += s*this.getElement(0, i) * manja.izracunajDeterminantu();
		    }
		    return sum; 
	}

	public void inicijaliziraj(int row, int col) {
		this.setCol(col);
		this.setRow(row);
		for (int i = 0; i < row; i++) {
			this.getMatrica().add(new ArrayList<Double>());
			for (int j = 0; j < col; j++) 
				this.getMatrica().get(i).add(j, 0.0);
		}
	}
}
