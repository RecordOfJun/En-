package controller;
import model.*;
import view.*;
import utility.Constant;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.text.DecimalFormat;

import javax.swing.JButton;

public class Calculation {
	private ButtonPanel buttonPanel;
	private TextPanel textPanel;
	private LogPanel logPanel;
	public State state;
	public NumberList status;
	public Calculation(ButtonPanel buttonPanel,TextPanel textPanel,LogPanel logPanel,State state,NumberList status) {
		this.status=status;
		this.state= state;
		this.buttonPanel=buttonPanel;
		this.textPanel=textPanel;
		this.logPanel=logPanel;
	}
	private void checkIsError() {
		if(state.getIsError()) {
			state.setIsError(false);
			status.setNumber("0");
			status.setUpField("");
			buttonPanel.setButtonEnable(true);
		}
	}
	public void detectOperator(String operator) {//연산자가 들어왔음
		if(!state.getIsError()) {
			//위 필드가 채워져있을 때 마지막에 숫자였다면
			if(status.getUpField()!=""&&state.getLastType()==Constant.TYPE_NUMBER&&!status.getUpField().endsWith("=")) {
				//NUMBER와 UPFEILD 합쳐서 값 계산
				String result=calculate(String.format("%s %s",status.getUpField(),status.getNumber()));
				status.setNumber(result);
			}
			else if(state.getLastType()==Constant.TYPE_OPERATOR&&status.getUpField().endsWith(")")) {
				String result=calculate(status.getUpField());
				status.setNumber(result);
			}
			//모든 경우 다 아래 숫자와 연산자가 합쳐져서 위 필드로 올라감
			if(state.getLastType()==Constant.TYPE_EQUAL&&status.getUpFieldText().endsWith(")"))
				status.setUpField(String.format("negate(%s) %s", status.getNumber(),operator));
			else
				status.setUpField(String.format("%s %s", status.getNumber(),operator));
			state.setLastType(Constant.TYPE_OPERATOR);
			//마지막에 연산자가 들어왔다고 알림
		}
	}
	
	public void detectEqual() {//=입력 감지
		if(!state.getIsError()){//마지막 타입 =이라고 알림
			if(status.getUpField()=="") {//위 필드가 비워져 있다면 아래 숫자와 = 합쳐서 위필드로 올림
				status.setUpField(status.getNumber()+"=");
			}
			else {//위 필드가 비어져 있지 않을 때
				if(status.getUpField().endsWith("=")) {
					String upField=status.getUpField();
					//연산자와 =이 같이 있다면
					if(upField.contains("×")||upField.contains("+")||upField.contains("-")||upField.contains("÷")) 
						calculateEqual(upField);
				}
				else
					calculateOperator();
			}
			state.setIsLog(false);
			state.setLastType(Constant.TYPE_EQUAL);
		}
		else
			checkIsError();
	}
	private void calculateOperator() {
		String result;
		//NUMBER와 UPFEILD 합쳐서 값 계산
		if(status.getUpField().split(" ").length==2) {
			result=calculate(String.format("%s %s",status.getUpField(),status.getNumber()));
			status.setUpField(status.getUpField()+" "+status.getNumber()+"=");
		}
		else {
			result=calculate(status.getUpField());
			status.setUpField(status.getUpField()+"=");
		}
		status.setNumber(result);
	}
	private void calculateEqual(String upField) {
		String[] temporary=upField.split(" ");//연산자 기준으로 두개로 나눔
		if(state.getIsLog()) {
			if(status.getUpFieldText().contains("="))
				temporary[2]=status.getNumber()+"=";//오른쪽에 아래 숫자를 넣어줌
			else {
				temporary[2]=status.getUpFieldText()+"=";
				status.setUpFieldText("");
			}
			temporary[0]=deleteNegate(temporary[0])+"=";
		}
		else {
			if(status.getUpFieldText()!=""&&!status.getUpFieldText().contains("=")) {
				temporary[0]=status.getUpFieldText();
				status.setUpFieldText("");
			}
			else {
				temporary[0]=status.getNumber();//왼쪽에 아래 숫자를 넣어줌
			}
			temporary[2]=deleteNegate(temporary[2]);
		}
		status.setUpField(String.format("%s %s %s",temporary[0],temporary[1],temporary[2]));//위 필드를 최신화해줌
		String result=calculate(status.getUpField());
		status.setNumber(result);
	}
	
	
	private String calculate(String formula) {
		String[] temporary=formula.replace("=", "").split(" "); 
		BigDecimal leftNumber=new BigDecimal(deleteNegate(temporary[0]));
		BigDecimal rightNumber=new BigDecimal(deleteNegate(temporary[2]));
		BigDecimal result=new BigDecimal("0");
		String resultToString="";
		try {
			switch(temporary[1]) {
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
		}
		catch(Exception e) {
			if(e.getMessage()=="Division undefined") {
				resultToString="정의되지 않은 결과입니다";
				setError();
				return resultToString;
			}
			else if(e.getMessage()=="Division by zero") {
				resultToString="0으로 나눌 수 없습니다";
				setError();
				return resultToString;
			}
			else
				result=leftNumber.divide(rightNumber,MathContext.DECIMAL128);
		}
		System.out.println(result.toString());
		if(result.compareTo(new BigDecimal("9.999999999999999e+9999"))==1||result.compareTo(new BigDecimal("-9.999999999999999e+9999"))==-1||result.compareTo(new BigDecimal("0"))!=0&&result.compareTo(new BigDecimal("1e-9999"))==-1&&result.compareTo(new BigDecimal("-1e-9999"))==1) {
			resultToString="오버플로";
			setError();
			return resultToString;
		}
		else if(result.compareTo(new BigDecimal("0"))==0)
			resultToString="0";
		else
			resultToString=result.toString();
		formula=String.format("%s %s %s=", textPanel.convertNumber(temporary[0], 0),temporary[1],textPanel.convertNumber(temporary[2], 0));
		logPanel.addButton(formula,textPanel.convertNumber(resultToString, 1));
		state.setIsLog(false);
		return resultToString;
	}
	private void setError() {
		status.setUpField("");
		state.setLastType(Constant.TYPE_NUMBER);
		state.setIsError(true);
		buttonPanel.setButtonEnable(false);
	}
	private String deleteNegate(String number) {
		int negateCount=0;
		for(int count=0;count<number.length();count++) {
			if(number.substring(count).startsWith("(")) {
				negateCount++;
			}
		}
		if(negateCount%2==1)
			return convertSign(number.replace("negate", "").replace("(", "").replace(")", ""));
		else
			return number.replace("negate", "").replace("(", "").replace(")", "");
	}
	private String convertSign(String number) {
		if(number.startsWith("-"))
			return number.substring(1);
		else
			return "-"+number;
	}
}
