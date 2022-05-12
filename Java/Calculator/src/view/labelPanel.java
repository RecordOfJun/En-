package view;
import java.awt.*;
import javax.swing.*;
public class labelPanel extends JPanel {
	private JTextField calculateLog=new JTextField("log");
	private JTextField presentNumber=new JTextField("num");
	
	private void setPanel() {
		this.setLayout(new GridLayout(2,1,0,10));
		setLogField();
		setNumberField();
		this.add(calculateLog);
		this.add(presentNumber);
	}
	
	private void setLogField() {
		calculateLog.setHorizontalAlignment(JTextField.RIGHT);
		calculateLog.setFont(new Font("돋움",Font.PLAIN,30));
		calculateLog.setSize(new Dimension(this.WIDTH,30));
	}
	private void setNumberField() {
		calculateLog.setHorizontalAlignment(JTextField.RIGHT);
		presentNumber.setFont(new Font("돋움",Font.BOLD,60));
		presentNumber.setSize(new Dimension(this.WIDTH,60));
	}
}
