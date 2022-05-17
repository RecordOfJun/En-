package controller;
import model.*;
import view.*;
import utility.Constant;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.math.BigDecimal;
import java.text.DecimalFormat;

import javax.swing.JButton;

public class Calculation {
	public NumberList status;
	private String number;
	private ButtonPanel buttonPanel;
	private TextPanel textPanel;
	private LogPanel logPanel;
	public Calculation(ButtonPanel buttonPanel,TextPanel textPanel,LogPanel logPanel) {
		status=new NumberList();
		this.buttonPanel=buttonPanel;
		this.textPanel=textPanel;
		this.logPanel=logPanel;
	}
	public void initAll() {
		status.setNumber("0");
		status.setUpField("");
		status.setLastType(Constant.TYPE_NUMBER);
		checkIsError();
		status.setIsLog(false);
	}
	public void initLast() {
		status.setNumber("0");
		status.setLastType(Constant.TYPE_NUMBER);
		checkIsError();
	}
	private void checkIsError() {
		if(status.getIsError()) {
			status.setIsError(false);
			status.setNumber("0");
			status.setUpField("");
			buttonPanel.setButtonEnable(true);
		}
	}
	//부호 달기
	public void appendSign() {
		if(!status.getIsError()) {
			number=status.getNumber();
			if(number.startsWith("-"))
				number=number.substring(1);
			else
				if(number!="0")
					number="-"+number;
			status.setNumber(number);
			if(status.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
				status.setUpFieldText("");
			}
		}
		//negative 붙이냐 마냐=>숫자 턴인지 아닌지
		System.out.println(number);
	}
	public void detectNumber(String number) {//숫자를 쳤음
		checkIsError();
		//위 필드가 채워져있을 때 마지막에 연산자가 들어왔었다면
		if(status.getLastType()==Constant.TYPE_OPERATOR&&status.getUpField()!="") {
			status.setNumber("0");//숫자만 초기화
		}
		else if(status.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
			status.setNumber("0");
			if(!status.getIsLog())
				status.setUpFieldText("");
		}
		//위 필드가 채워지지 않았을 경우&위 필드가 채워져있는데 이전에 숫자를 쳤었다면
		appendNumber(number);
	}
	
	public void detectOperator(String operator) {//연산자가 들어왔음
		if(!status.getIsError()) {
			//위 필드가 채워져있을 때 마지막에 숫자였다면
			if(status.getUpField()!=""&&status.getLastType()==Constant.TYPE_NUMBER&&!status.getUpField().endsWith("=")) {
				//NUMBER와 UPFEILD 합쳐서 값 계산
				String result=calculate(String.format("%s %s",status.getUpField(),status.getNumber()));
				status.setNumber(result);
			}
			//모든 경우 다 아래 숫자와 연산자가 합쳐져서 위 필드로 올라감
			status.setUpField(String.format("%s %s", status.getNumber(),operator));
			status.setLastType(Constant.TYPE_OPERATOR);
			//마지막에 연산자가 들어왔다고 알림
		}
	}
	
	public void detectEqual() {//=입력 감지
		if(!status.getIsError()){//마지막 타입 =이라고 알림
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
						if(status.getIsLog())
							temp[2]=status.getNumber()+"=";
						else
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
			status.setLastType(Constant.TYPE_EQUAL);
		}
		else
			checkIsError();
	}
	
	public void detectDot() {
		if(!status.getIsError()) {
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
	}
	
	public void detectBackSpace() {
		if(!status.getIsError()) {
			if(status.getLastType()==Constant.TYPE_NUMBER)
				removeNumber();
			else if(status.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
				status.setUpFieldText("");
			}
		}
		else
			checkIsError();
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
	
	private String calculate(String formula) {
		String[] temp=formula.replace("=", "").split(" "); 
		BigDecimal leftNumber=new BigDecimal(temp[0]);
		BigDecimal rightNumber=new BigDecimal(temp[2]);
		BigDecimal result=new BigDecimal("0");
		String resultToString="";
		try {
			switch(temp[1]) {
			case"÷":
				result=leftNumber.divide(rightNumber);
				break;
			case"×":
				result=leftNumber.multiply(rightNumber);
				break;
			case"+":
				result=leftNumber.add(rightNumber);
				break;
			case"-":
				result=leftNumber.subtract(rightNumber);
				break;
			}
			System.out.println(leftNumber+" "+rightNumber+" "+result);
			if(result.compareTo(new BigDecimal("9.999999999999999e+9999"))==1) {
				resultToString="오버플로";
				setError();
				return resultToString;
			}
			else if(result.compareTo(new BigDecimal("0"))==0)
				resultToString="0";
			else
				resultToString=result.toString();
			formula=String.format("%s %s %s=", textPanel.convertNumber(temp[0], 0),temp[1],textPanel.convertNumber(temp[2], 0));
			status.logList.add(0, formula);
			status.resultList.add(0,resultToString);
			logPanel.addButton(formula,textPanel.convertNumber(resultToString, 2));
		}
		catch(Exception e) {
			if(e.getMessage()=="Division undefined")
				resultToString="정의되지 않은 결과입니다";
			else
				resultToString="0으로 나눌 수 없습니다";
			setError();
			return resultToString;
		}
		status.setIsLog(false);
		return resultToString;
	}
	private void setError() {
		status.setUpField("");
		status.setLastType(Constant.TYPE_NUMBER);
		status.setIsError(true);
		buttonPanel.setButtonEnable(false);
	}
}
