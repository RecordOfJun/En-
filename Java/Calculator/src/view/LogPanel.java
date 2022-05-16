package view;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
public class LogPanel extends JPanel {
	private JPanel recordPanel=new JPanel();
	private JPanel deletePanel=new JPanel();
	private JButton deleteButton=new JButton();
	private Box mainBox = Box.createVerticalBox();
	BoxLayout layout=new BoxLayout(recordPanel,BoxLayout.Y_AXIS);
	public LogPanel() {
		this.setLayout(new BorderLayout());
		recordPanel.setLayout(layout);
		recordPanel.add(mainBox);
		deletePanel.setLayout(new FlowLayout(FlowLayout.RIGHT));
		deletePanel.add(deleteButton);
		this.add(recordPanel,BorderLayout.CENTER);
		this.add(deletePanel,BorderLayout.SOUTH);
	}
	public void addButton(String formula,String result) {
		JButton button=new JButton();
		button.setHorizontalAlignment(SwingConstants.RIGHT);
		button.setMaximumSize(new Dimension(450,60));
		button.setMinimumSize(new Dimension(450,60));
		//button.setPreferredSize(new Dimension(450,60));
		button.setText(formula);
		mainBox.add(button,0);
	}
}
