package model;
import java.util.*;
public class NumberList {
	private ArrayList<String> number;
	private double result;
	private String lastOperator;
	private String lastNumber;
	private int lastType;
	public NumberList() {
		number=new ArrayList<String>();
		result=0;
	}
	public double getResult() {
		return result;
	}
	public void setResult(double result) {
		this.result=result;
	}
	public String getLastOperator() {
		return lastOperator;
	}
	public void setLastOperator(String lastOperator) {
		this.lastOperator=lastOperator;
	}
	public String getLastNumber() {
		return lastNumber;
	}
	public void setLastNumber(String lastNumber) {
		this.lastNumber=lastNumber;
	}
	public int getLastType() {
		return lastType;
	}
	public void setLastType(int lastType) {
		this.lastType=lastType;
	}
}
