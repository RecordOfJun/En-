package view;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

import utility.Constant;
public class MenuPanel extends JPanel {
	private JLabel defaultLabel=new JLabel("표준");
	public JButton logButton=new JButton(new ImageIcon(new ImageIcon("image/log.PNG").getImage().getScaledInstance(40, 40, Image.SCALE_SMOOTH)));
	private JPanel leftPanel=new JPanel();
	private JPanel rightPanel=new JPanel();
	public MenuPanel() {
		setPanel();
	}
	private void setPanel() {
		defaultLabel.setPreferredSize(new Dimension(400,40));
		defaultLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		logButton.setPreferredSize(new Dimension(40,40));
		//logButton.setBorder(null);
		logButton.setBorderPainted(false); 
		logButton.setFocusPainted(false); 
		logButton.addMouseListener(new logAdapter());
		this.setLayout(new GridLayout(1,2));
		setLayOut();
		rightPanel.add(logButton);
		this.add(leftPanel);
		this.add(rightPanel);
	}
	private void setLayOut() {
		leftPanel.setLayout(new FlowLayout(FlowLayout.LEFT));
		leftPanel.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		rightPanel.setLayout(new FlowLayout(FlowLayout.RIGHT));
		rightPanel.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		leftPanel.add(defaultLabel);
	}
	private class logAdapter extends MouseAdapter {
		public void mouseEntered(MouseEvent e) {
			e.getComponent().setForeground(Color.LIGHT_GRAY);
		}
		public void mouseExited(MouseEvent e) {
			e.getComponent().setForeground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		}
	}
	public void addLogListener(ActionListener listener) {
		logButton.addActionListener(listener);
	}
	public void convertToLogColor() {
		leftPanel.setBackground(Color.LIGHT_GRAY);
		rightPanel.setBackground(Color.LIGHT_GRAY);
	}
	public void convertToCalculatorColor() {
		leftPanel.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		rightPanel.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
	}
}
