package controller;

import model.NumberList;
import model.State;
import utility.Constant;
import view.ButtonPanel;
import view.TextPanel;

public class NumberProcessing {
	private String number;
	private ButtonPanel buttonPanel;
	private TextPanel textPanel;
	public State state;
	public NumberList status;
	public NumberProcessing(ButtonPanel buttonPanel,TextPanel textPanel,State state,NumberList status) {
		this.status=status;
		this.state= state;
		this.buttonPanel=buttonPanel;
		this.textPanel=textPanel;
	}
	public void initAll() {
		status.setNumber("0");
		status.setUpField("");
		state.setLastType(Constant.TYPE_NUMBER);
		checkIsError();
		state.setIsLog(false);
	}
	public void initLast() {
		status.setNumber("0");
		state.setLastType(Constant.TYPE_NUMBER);
		checkIsError();
	}
	private void checkIsError() {
		if(state.getIsError()) {
			state.setIsError(false);
			status.setNumber("0");
			status.setUpField("");
			buttonPanel.setButtonEnable(true);
		}
	}
	public void appendSign() {
		if(!state.getIsError()) {
			if(state.getIsLog()) {
				String[] temporary=status.getUpFieldText().split(" ");
				if(temporary.length==3&&temporary[2].contains("=")) {
					String negate="negate("+textPanel.convertNumber(status.getNumber(),0)+")";
					status.setUpField(String.format("%s %s %s", temporary[0],temporary[1],negate));
				}
				else {
					String negate="negate("+textPanel.convertNumber(temporary[2],0)+")";
					status.setUpField(String.format("%s %s %s", temporary[0],temporary[1],negate));
				}
			}
			else if(state.getLastType()==Constant.TYPE_EQUAL) {
				if(status.getUpFieldText().toString().endsWith(")")) {
					status.setUpFieldText("negate("+textPanel.convertNumber(status.getUpFieldText(),0)+")");
				}
				else{
					status.setUpFieldText("negate("+textPanel.convertNumber(status.getNumber(),0)+")");
				}
			}
			else if(state.getLastType()==Constant.TYPE_OPERATOR) {
				String[] temporary=status.getUpFieldText().split(" ");
				if(temporary.length==2) {
					String negate="negate("+textPanel.convertNumber(status.getNumber(),0)+")";
					status.setUpField(String.format("%s %s %s", temporary[0],temporary[1],negate));
				}
				else {
					String negate="negate("+textPanel.convertNumber(temporary[2],0)+")";
					status.setUpField(String.format("%s %s %s", temporary[0],temporary[1],negate));
				}
			}
			number=status.getNumber();
			if(number.startsWith("-"))
				number=number.substring(1);
			else
				if(number!="0")
					number="-"+number;
			status.setNumber(number);
		}
		//negative ????????? ??????=>?????? ????????? ?????????
	}
	public void detectNumber(String number) {//????????? ??????
		checkIsError();
		//??? ????????? ??????????????? ??? ???????????? ???????????? ??????????????????
		if(state.getLastType()==Constant.TYPE_OPERATOR&&status.getUpField()!=""||status.getUpField().endsWith(")")) {
			String[] temporary=status.getUpField().split(" ");
			status.setUpField(temporary[0]+" "+temporary[1]);
			status.setNumber("0");//????????? ?????????
		}
		else if(state.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
			status.setNumber("0");
			if(!state.getIsLog()&&status.getUpField().split(" ").length!=1)
				status.setUpFieldText("");
		}
		//??? ????????? ???????????? ????????? ??????&??? ????????? ?????????????????? ????????? ????????? ????????????
		appendNumber(number);
	}
	public void detectDot() {
		if(!state.getIsError()) {
			//??? ????????? ??????????????? ??? ???????????? ???????????? ??????????????????
			if(state.getLastType()==Constant.TYPE_OPERATOR&&status.getUpField()!="") {
				status.setNumber("0");//????????? ?????????
			}
			//??? ????????? ????????? ?????? ??? ???????????? =??? ??????????????????
			else if(state.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!="") {
				status.setNumber("0");
				status.setUpFieldText("");
			}
			//??? ????????? ???????????? ????????? ??????&??? ????????? ?????????????????? ????????? ????????? ????????????
			appendDot();
		}
	}
	
	public void detectBackSpace() {
		if(!state.getIsError()) {
			if(state.getLastType()==Constant.TYPE_NUMBER)
				removeNumber();
			else if(state.getLastType()==Constant.TYPE_EQUAL&&status.getUpField()!=""&&status.getUpField().split(" ").length!=1) {
				status.setUpFieldText("");
			}
		}
		else
			checkIsError();
	}
	private void appendNumber(String number) {
		//??????????????? ,??????
		this.number=status.getNumber();
		if(this.number.charAt(0)=='0'&&this.number.length()==1) {
			this.number=number;
		}
		else { 
			String replacement=this.number.replace("-","").replace(".", "");
			if(replacement.charAt(0)=='0')
				replacement=replacement.substring(1);
			if(replacement.length()<16)
				this.number=this.number+number;
		}
		status.setNumber(this.number);
		state.setLastType(Constant.TYPE_NUMBER);
		//status.setIsLog(false);
	}
	
	private void appendDot() {
		number=status.getNumber();
		if(!number.contains(".")) {
			number=number.concat(".");
		}
		status.setNumber(number);
		state.setLastType(Constant.TYPE_NUMBER);
	}
	private void removeNumber() {
		this.number=status.getNumber();
		number=number.substring(0,number.length()-1);
		if(number.compareTo("")==0||number.compareTo("-")==0)
			number="0";
		status.setNumber(this.number);
		state.setLastType(Constant.TYPE_NUMBER);
	}
}
