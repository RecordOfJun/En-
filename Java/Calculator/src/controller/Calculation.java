package controller;
import model.*;
import view.*;
import utility.Constant;

import java.math.BigDecimal;
import java.text.DecimalFormat;

public class Calculation {
	NumberList status;
	private String number;
	private ButtonPanel buttonPanel;
	public Calculation(ButtonPanel buttonPanel) {
		status=new NumberList();
		this.buttonPanel=buttonPanel;
	}
	public void initAll() {
		status.setNumber("0");
		status.setUpField("");
		status.setLastType(Constant.TYPE_NUMBER);
	}
	public void initLast() {
		status.setNumber("0");
		status.setLastType(Constant.TYPE_NUMBER);
	}
	//부호 달기
	public void appendSign() {
		number=status.getNumber();
		if(number.contains("-"))
			number=number.replace("-", "");
		else
			if(number!="0")
				number="-"+number;
		status.setNumber(number);
		if(status.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
			status.setUpFieldText("");
		}
		//negative 붙이냐 마냐=>숫자 턴인지 아닌지
		System.out.println(number);
	}
	public void detectNumber(String number) {//숫자를 쳤음
		//위 필드가 채워져있을 때 마지막에 연산자가 들어왔었다면
		if(status.getLastType()==Constant.TYPE_OPERATOR&&status.getUpField()!="") {
			status.setNumber("0");//숫자만 초기화
		}
		else if(status.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
			status.setNumber("0");
			status.setUpFieldText("");
		}
		//위 필드가 채워지지 않았을 경우&위 필드가 채워져있는데 이전에 숫자를 쳤었다면
		appendNumber(number);
	}
	
	public void detectOperator(String operator) {//연산자가 들어왔음
		status.setNumber(new BigDecimal(status.getNumber()).stripTrailingZeros().toPlainString());
		//위 필드가 채워져있을 때 마지막에 숫자였다면
		if(status.getUpField()!=""&&status.getLastType()==Constant.TYPE_NUMBER) {
			//NUMBER와 UPFEILD 합쳐서 값 계산
			String result=calculate(String.format("%s %s",status.getUpField(),status.getNumber()));
			status.setNumber(result);
		}
		//모든 경우 다 아래 숫자와 연산자가 합쳐져서 위 필드로 올라감
		status.setUpField(String.format("%s %s", status.getNumber(),operator));
		status.setLastType(Constant.TYPE_OPERATOR);
		//마지막에 연산자가 들어왔다고 알림
	}
	
	public void detectEqual() {//=입력 감지
		status.setNumber(new BigDecimal(status.getNumber()).stripTrailingZeros().toPlainString());
		if(status.getUpField()=="") {//위 필드가 비워져 있다면 아래 숫자와 = 합쳐서 위필드로 올림
			status.setUpField(status.getNumber()+"=");
		}
		else {//위 필드가 비어져 있지 않을 때
			if(status.getUpField().endsWith("=")) {
				String upField=status.getUpField();
				//연산자와 =이 같이 있다면
				if(upField.contains("×")||upField.contains("+")||upField.contains("-")||upField.contains("÷")) {
					String[] temp=upField.split(" ");//연산자 기준으로 두개로 나눔
					System.out.println(temp[0]);
					temp[0]=status.getNumber();//왼쪽에 아래 숫자를 넣어줌
					status.setUpField(String.format("%s %s %s",temp[0],temp[1],temp[2]));//위 필드를 최신화해줌
					String result=calculate(status.getUpField());
					status.setNumber(result);
				}
			}
			else {//위 필드가 연산자로 끝날 때
				//NUMBER와 UPFEILD 합쳐서 값 계산
				String result=calculate(String.format("%s %s",status.getUpField(),status.getNumber()));
				status.setUpField(status.getUpField()+" "+status.getNumber()+"=");
				status.setNumber(result);
			}
		}
		status.setLastType(Constant.TYPE_EQUAL);//마지막 타입 =이라고 알림
	}
	
	public void detectDot() {
		//위 필드가 채워져있을 때 마지막에 연산자가 들어왔었다면
		if(status.getLastType()==Constant.TYPE_OPERATOR&&status.getUpField()!="") {
			status.setNumber("0");//숫자만 초기화
		}
		//위 필드가 채워져 있을 때 마지막에 =이 들어왔었다면
		else if(status.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
			status.setNumber("0");
			status.setUpFieldText("");
		}
		//위 필드가 채워지지 않았을 경우&위 필드가 채워져있는데 이전에 숫자를 쳤었다면
		appendDot();
	}
	
	public void detectBackSpace() {
		if(status.getLastType()==Constant.TYPE_NUMBER)
			removeNumber();
		else if(status.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
			status.setUpFieldText("");
		}
	}
	private void appendNumber(String number) {
		//정수부분에 ,달기
		this.number=status.getNumber();
		if(this.number.charAt(0)=='0'&&this.number.length()==1) {
			System.out.println(this.number);
			this.number=number;
		}
		else { 
			String replacement=this.number.replace("-","").replace(".", "");
			if(replacement.charAt(0)=='0')
				replacement=replacement.substring(1);
			if(replacement.length()<16)
				this.number=this.number+number;
			System.out.println("y");
		}
		status.setNumber(this.number);
		status.setLastType(Constant.TYPE_NUMBER);
		System.out.println(this.number);
	}
	
	private void appendDot() {
		number=status.getNumber();
		if(!number.contains(".")) {
			number=number.concat(".");
		}
		status.setNumber(number);
		status.setLastType(Constant.TYPE_NUMBER);
		System.out.println(number);
	}
	private void removeNumber() {
		this.number=status.getNumber();
		number=number.substring(0,number.length()-1);
		if(number.compareTo("")==0||number.compareTo("-")==0)
			number="0";
		status.setNumber(this.number);
		status.setLastType(Constant.TYPE_NUMBER);
	}
	private String convertFormat(Double number) {
		DecimalFormat numberFormat=new DecimalFormat("################.################");
		return numberFormat.format(number).toString();
	}
	
	private String calculate(String formula) {
		String[] temp=formula.replace("=", "").split(" ");
		double leftNumber=Double.parseDouble(temp[0]);
		double rightNumber=Double.parseDouble(temp[2]);
		double result=0;
		switch(temp[1]) {
			case"÷":
				result=leftNumber/rightNumber;
				break;
			case"×":
				result=leftNumber*rightNumber;
				break;
			case"+":
				result=leftNumber+rightNumber;
				break;
			case"-":
				result=leftNumber-rightNumber;
				break;
		}
		String resultToString;

		if(Double.isNaN(result)||Double.isInfinite(result)) {
			resultToString="정의되지않은결과입니다";
			status.setUpField("");
			status.setLastType(Constant.TYPE_NUMBER);
			//buttonPanel.setButtonDisabled();
		}
		else if(result>=1e+17)
			resultToString=String.format("%e",result);
		else
			resultToString=convertFormat(result);
		return resultToString;
	}
}
