package view;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.event.MouseAdapter;
import java.beans.PropertyChangeEvent;
import java.beans.PropertyChangeListener;
import java.beans.PropertyChangeListenerProxy;
import java.math.BigDecimal;
import java.text.DecimalFormat;

import javax.swing.*;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;

import utility.Constant;
public class TextPanel extends JPanel {
	public JLabel calculateLog=new JLabel("");
	public JLabel presentNumber=new JLabel("0");
	
	public TextPanel() {
		setPanel();
		setLogField();
		setNumberField();
	}
	private void setPanel() {
		this.setLayout(new GridLayout(2,1,0,0));
		this.setPreferredSize(new Dimension(300,60));
		this.add(calculateLog);
		this.add(presentNumber);
	}
	
	private void setLogField() {
		calculateLog.setHorizontalAlignment(JTextField.RIGHT);
		calculateLog.setFont(new Font("맑은 고딕",Font.PLAIN,15));
		calculateLog.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		calculateLog.setBorder(null);
	}
	private void setNumberField() {
		presentNumber.setHorizontalAlignment(JTextField.RIGHT);
		presentNumber.setFont(new Font("돋움",Font.BOLD,50));
		presentNumber.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		presentNumber.setBorder(null);
	}
	public void setPresentText(String number) {
		
	}
	public void setPresentNumberText(String number,int type) {
		if(number.contains("다")) {
			presentNumber.setText(number);
		}
		else {
			String text=convertNumber(number,type);
			presentNumber.setText(text.replace("E","e"));
		}
	}
	public void setLogNumberText(String log) {
		String text="";
		if(log!="") {
			String[] temp=log.split(" ");
			if(temp.length==1) {
				if(temp[0].contains("="))
					text=convertNumber(temp[0].replace("=", ""),0)+"=";
				else
					text=temp[0];
			}
			else if(temp.length==2) {
				text=convertNumber(temp[0],0)+" "+temp[1];
			}
			else if(temp.length==3) {
				if(temp[2].contains("=")) {
					text=convertNumber(temp[0],0)+" "+temp[1]+" "+convertNumber(temp[2].replace("=", ""),0)+"=";
				}
				else
					text=convertNumber(temp[0],0)+" "+temp[1]+" "+convertNumber(temp[2],0);
			}
		}
		calculateLog.setText(text);
	}
	public String convertNumber(String number,int type) {
		String text=number;
		if(!number.contains("오")&&!number.contains("다")&&!number.contains("(")) {
			BigDecimal result=new BigDecimal(number.replace("=", ""));
			DecimalFormat numberFormat;
			if(result.compareTo(new BigDecimal("9.999999999999999e+15"))==1||result.compareTo(new BigDecimal("-9.999999999999999e+15"))==-1) {
				numberFormat=new DecimalFormat("0.###############E0");
			}
			else if(result.compareTo(new BigDecimal("0"))!=0&&((result.compareTo(new BigDecimal("1e-3"))==-1&&result.compareTo(new BigDecimal("-1e-3"))==1&&result.toString().replace(".","").replace("-","").length()>17)||(result.compareTo(new BigDecimal("1e-16"))==-1&&result.compareTo(new BigDecimal("-1e-16"))==1))){
				numberFormat=new DecimalFormat("0.###############E0");
			}
			else{

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
			text=numberFormat.format(result).toString().replace("E", "e+");
			if(text.substring(1).contains("-")) {
				text=text.replace("+", "");
			}
		}
		
		return text;
	}
	public void convertToLogColor() {
		this.setBackground(Color.LIGHT_GRAY);
	}
	public void convertToCalculatorColor() {
		this.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
	}
	public void addFrameConvert(MouseAdapter adapter) {
		calculateLog.addMouseListener(adapter);
		presentNumber.addMouseListener(adapter);
	}
	public class textChangeListener implements DocumentListener {

		@Override
		public void insertUpdate(DocumentEvent e) {
			if(presentNumber.getText().length()>8)
				presentNumber.setFont(new Font("돋움",Font.BOLD,35));
			else
				presentNumber.setFont(new Font("돋움",Font.BOLD,50));
		}

		@Override
		public void removeUpdate(DocumentEvent e) {
			if(presentNumber.getText().length()>8)
				presentNumber.setFont(new Font("돋움",Font.BOLD,35));
			else
				presentNumber.setFont(new Font("돋움",Font.BOLD,50));
		}

		@Override
		public void changedUpdate(DocumentEvent e) {
			if(presentNumber.getText().length()>8)
				presentNumber.setFont(new Font("돋움",Font.BOLD,35));
			else
				presentNumber.setFont(new Font("돋움",Font.BOLD,50));
		}
	}
	public class textLabelListener extends ComponentAdapter {
        public void componentResized(ComponentEvent e) {
        	int size=50;
        	while(presentNumber.getPreferredSize().getWidth()>presentNumber.getWidth()) {
        		presentNumber.setFont(new Font("맑은 고딕",Font.BOLD,size));
        		size--;
        		if(size==0)
        			break;
        	}
        }
	}
}
