package view;
import java.awt.*;
import javax.swing.*;
public class labelPanel extends JPanel {
	private JTextField calculateLog=new JTextField("log");
	private JTextField presentNumber=new JTextField("num");
	
	public labelPanel() {
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
		calculateLog.setBackground(new Color(225,225,225));
		calculateLog.setBorder(null);
		calculateLog.setEditable(false);
	}
	private void setNumberField() {
		presentNumber.setHorizontalAlignment(JTextField.RIGHT);
		presentNumber.setFont(new Font("돋움",Font.BOLD,60));
		//presentNumber.setPreferredSize(new Dimension(this.WIDTH,60));
		presentNumber.setBackground(new Color(225,225,225));
		presentNumber.setBorder(null);
		presentNumber.setEditable(false);
	}
}
