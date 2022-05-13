package model;
import java.util.*;
public class NumberList {
	private String number;
	private String upField;
	private int lastType;
	public NumberList() {
		number="0";
		upField="";
	}
	public String getNumber() {
		return number;
	}
	public void setNumber(String number) {
		this.number=number;
	}
	public int getLastType() {
		return lastType;
	}
	public void setLastType(int lastType) {
		this.lastType=lastType;
	}
	public void setUpField(String content) {
		upField=content;
	}
	public String getUpField() {
		return upField;
	}
}
