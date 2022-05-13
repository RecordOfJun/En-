package controller;
import model.*;
import utility.Constant;
public class Calculation {
	NumberList status;
	private String number;
	public Calculation() {
		status=new NumberList();
	}
	public String initAll() {
		status.setNumber("0");
		status.setLastNumber(null);
		status.setLastOperator(null);
		status.setLastType(Constant.TYPE_NULL);
		return status.getNumber();
	}
	//부호 달기
	public String appendSign() {
		number=status.getNumber();
		if(number.contains("-"))
			number=number.replace("-", "");
		else
			if(number!="0")
				number="-"+number;
		status.setNumber(number);
		System.out.println(number);
		return number;
	}
	public String appendNumber(String number) {
		this.number=status.getNumber();
		if(this.number.compareTo("0")==0)
			this.number=number;
		else { 
			if(this.number.replaceAll("/(0.|.|-)/", "").length()<16)
				this.number=this.number+number;
		}
		status.setNumber(this.number);
		System.out.println(this.number);
		return this.number;
	}
	public String appendDot(String dot) {
		number=status.getNumber();
		if(!number.contains(dot)) {
			number=number.concat(dot);
		}
		status.setNumber(number);
		System.out.println(number);
		return number;
	}
}
