package view;
import java.awt.*;
import javax.swing.*;
public class menuPanel extends JPanel {
	private JLabel defaultLabel=new JLabel("표준");
	private JButton logButton=new JButton();
	private JPanel leftPanel=new JPanel();
	private JPanel rightPanel=new JPanel();
	public menuPanel() {
		setPanel();
	}
	private void setPanel() {
		this.setLayout(new GridLayout(1,2));
		leftPanel.setLayout(new FlowLayout(FlowLayout.LEFT));
		rightPanel.setLayout(new FlowLayout(FlowLayout.RIGHT));
		leftPanel.add(defaultLabel);
		rightPanel.add(logButton);
		this.add(leftPanel);
		this.add(rightPanel);
	}
}
