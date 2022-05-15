package model;
import java.text.DecimalFormat;
import java.util.*;
public class NumberList {
	private String number;
	private String upField;
	private String upFieldText;
	private int lastType;
	private boolean isError;
	public NumberList() {
		number="0";
		upField="";
		upFieldText="";
		isError=false;
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
		upFieldText=upField;
	}
	
	public String getUpField() {
		return upField;
	}
	public void setUpFieldText(String content) {
		upFieldText=content;
	}
	
	public String getUpFieldText() {
		return upFieldText;
	}
	public void setIsError(boolean bool) {
		isError=bool;
	}
	public boolean getIsError() {
		return isError;
	}
}
