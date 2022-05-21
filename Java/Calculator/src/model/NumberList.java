package model;
import java.text.DecimalFormat;
import java.util.*;
public class NumberList {
	private String number;
	private String upField;
	private String upFieldText;
	public NumberList() {
		number="0";
		upField="";
		upFieldText="";
	}
	public String getNumber() {
		return number;
	}
	public void setNumber(String number) {
		this.number=number;
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
}
