package view;
import java.awt.*;
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
		//calculateLog.setPreferredSize(new Dimension(this.WIDTH,60));
		calculateLog.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		calculateLog.setBorder(null);
		calculateLog.setEditable(false);
	}
	private void setNumberField() {
		presentNumber.setHorizontalAlignment(JTextField.RIGHT);
		presentNumber.setFont(new Font("돋움",Font.BOLD,60));
		//presentNumber.setPreferredSize(new Dimension(this.WIDTH,60));
		presentNumber.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		presentNumber.setBorder(null);
		presentNumber.setEditable(false);
	}
}
