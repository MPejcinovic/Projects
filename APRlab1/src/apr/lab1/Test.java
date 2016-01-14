package apr.lab1;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Scanner;

/**
 * Class for testing 
 * @author Matea Pejèinoviæ
 * @version 1.0
 */
public class Test {

	public static void main(String[] argd) throws FileNotFoundException, IOException{
		Matrica mat1 = new Matrica();
		mat1.fillMatrix("mat1.txt");
		Matrica b = new Matrica();
		b.fillMatrix("mat2.txt");
		int n = mat1.getRow();
		int[] ind = new int[n];
		for (int i = 0; i < n; i++) {
			ind[i] = i;
		}
		
		System.out.println("ukoliko zelite provesti postupak LU dekomopozicije, upišite 0. Za LUP dekompoziciju upisite 1!");
		Scanner sc = new Scanner(System.in);
		int flag = sc.nextInt();
		if (flag == 0)
			mat1.LUDekompozicija();
		else if (flag == 1)
			mat1.LUPDekompozicija(ind);
		else
			System.out.println("Niste unijeli nijednu predvidjenu vrijednost!");
		Matrica k = mat1.supstitucijaUnaprijed(b, ind);
		System.out.println();
		System.out.println("Rezultat: ");
		k.printMatrixOnScreen();
		
	}
}
