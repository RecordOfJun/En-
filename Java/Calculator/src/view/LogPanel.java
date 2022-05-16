package view;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
public class LogPanel extends JPanel {
	BoxLayout layout=new BoxLayout(this,BoxLayout.Y_AXIS);
	public LogPanel() {
		this.setLayout(layout);
	}
	public void addButton(String formula,String result) {
		JButton button=new JButton();
		button.setHorizontalAlignment(SwingConstants.RIGHT);
		button.setMaximumSize(new Dimension(600,60));
		button.setMinimumSize(new Dimension(600,60));
		button.setPreferredSize(new Dimension(600,60));
		button.setText(formula);
		this.add(button,0);
	}
}
