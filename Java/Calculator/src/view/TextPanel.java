package view;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.math.BigDecimal;
import java.text.DecimalFormat;

import javax.swing.*;

import utility.Constant;
public class TextPanel extends JPanel {
	public JTextField calculateLog=new JTextField("");
	public JTextField presentNumber=new JTextField("0");
	
	public TextPanel() {
		setLogField();
		setNumberField();
		setPanel();
	}
	private void setPanel() {
		this.setLayout(new GridLayout(2,1,0,0));
		this.setPreferredSize(new Dimension(300,60));
		this.add(calculateLog);
		this.add(presentNumber);
	}
	
	private void setLogField() {
		calculateLog.setHorizontalAlignment(JTextField.RIGHT);
		calculateLog.setFont(new Font("돋움",Font.PLAIN,15));
		calculateLog.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		calculateLog.setBorder(null);
		calculateLog.setEditable(false);
	}
	private void setNumberField() {
		presentNumber.setHorizontalAlignment(JTextField.RIGHT);
		presentNumber.setFont(new Font("돋움",Font.BOLD,50));
		presentNumber.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		presentNumber.setBorder(null);
		presentNumber.setEditable(false);
	}
	public void setPresentText(String number) {
		
	}
	public void setPresentNumberText(String number,int type) {
		if(number.contains("다")) {
			presentNumber.setText(number);
			System.out.println("d");
		}
		else {
			String text=convertNumber(number,type);
			presentNumber.setText(text.replace("E","e"));
			System.out.println("s");
		}
	}
	public void setLogNumberText(String log) {
		String text="";
		if(log!="") {
			String[] temp=log.split(" ");
			if(temp.length==1) {
				text=convertNumber(temp[0].replace("=", ""),0)+"=";
			}
			else if(temp.length==2) {
				text=convertNumber(temp[0],0)+" "+temp[1];
			}
			else if(temp.length==3) {
				text=convertNumber(temp[0],0)+" "+temp[1]+" "+convertNumber(temp[2].replace("=", ""),0)+"=";
			}
		}
		calculateLog.setText(text);
	}
	public String convertNumber(String number,int type) {
		BigDecimal result=new BigDecimal(number);
		DecimalFormat numberFormat;
		if(result.compareTo(new BigDecimal("9.999999999999999e+15"))==1) {
			numberFormat=new DecimalFormat("0.################E0");
		}
		else if(result.compareTo(new BigDecimal("1e-16"))==1||result.compareTo(new BigDecimal("0"))==0) {

			if(type==0)//log
				numberFormat=new DecimalFormat("###############0.################");
			else if(type==1)//타이핑 완료 후
				numberFormat=new DecimalFormat("#,###,###,###,###,##0.################");
			else {//타이핑중일때
				String format="#,###,###,###,###,##0";
				if(number.contains(".")) {
					format+=".";
					String[] temp=number.split("\\.");
					if(temp.length==2) {
						System.out.println("in");
						int floatLength=0;
						floatLength=temp[1].length();
						for(int count=0;count<floatLength;count++) {
							format+="0";
						}
					}
 				}
				numberFormat=new DecimalFormat(format);	
			}
			
		}
		else {
			numberFormat=new DecimalFormat("0.################E0");
		}
		return numberFormat.format(result).toString();
	}
	public void convertToLogColor() {
		calculateLog.setBackground(Color.LIGHT_GRAY);
		presentNumber.setBackground(Color.LIGHT_GRAY);
	}
	public void convertToCalculatorColor() {
		calculateLog.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		presentNumber.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
	}
	public void addFrameConvert(MouseAdapter adapter) {
		calculateLog.addMouseListener(adapter);
		presentNumber.addMouseListener(adapter);
	}
}
