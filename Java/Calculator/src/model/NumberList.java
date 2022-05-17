package model;
import java.text.DecimalFormat;
import java.util.*;
public class NumberList {
	private String number;
	private String upField;
	private String upFieldText;
	public ArrayList<String> logList=new ArrayList<String>();
	public ArrayList<String> resultList=new ArrayList<String>();
	private int lastType;
	private boolean isError;
	private boolean isLog;
	public NumberList() {
		number="0";
		upField="";
		upFieldText="";
		isError=false;
		isLog=false;
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
	public void setIsLog(boolean bool) {
		isLog=bool;
	}
	public boolean getIsLog() {
		return isLog;
	}
}
