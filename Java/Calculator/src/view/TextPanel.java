package view;
import java.awt.*;
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
	
	public void setpresentNumberText(String number) {
		if(number.contains("다")) {
			presentNumber.setText(number);
			System.out.println("d");
		}
		else {
			Double text=Double.parseDouble(number);
			DecimalFormat numberFormat=new DecimalFormat("#,###,###,###,###,###.################");
			presentNumber.setText(numberFormat.format(text).toString());
			System.out.println("s");
		}
	}
}
