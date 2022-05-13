package model;
import java.util.*;
public class NumberList {
	private String number;
	private double leftNumber;
	private double rightNumber;
	private String lastOperator;
	private String lastNumber;
	private int lastType;
	public NumberList() {
		number="0";
	}
	public String getNumber() {
		return number;
	}
	public void setNumber(String number) {
		this.number=number;
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
