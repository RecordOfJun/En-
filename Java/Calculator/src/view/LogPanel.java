package view;
import java.awt.*;
import javax.swing.*;

import utility.Constant;
import controller.*;
import java.awt.event.*;
public class LogPanel extends JPanel {
	private JPanel recordPanel=new JPanel();
	private JPanel deletePanel=new JPanel();
	private JButton deleteButton=new JButton(new ImageIcon("image/trash.png"));
	private Box mainBox = Box.createVerticalBox();
	private JScrollPane scroll=new JScrollPane(recordPanel,ScrollPaneConstants.VERTICAL_SCROLLBAR_AS_NEEDED,ScrollPaneConstants.HORIZONTAL_SCROLLBAR_NEVER);
	private BoxLayout layout=new BoxLayout(recordPanel,BoxLayout.Y_AXIS);
	private JLabel label=new JLabel("아직 기록이 없음");
	private ActionListener listener;
	public LogPanel() {
		this.setLayout(new BorderLayout());
		label.setFont(new Font("맑은 고딕",Font.BOLD,20));
		mainBox.add(label);
		recordPanel.setLayout(layout);
		recordPanel.add(mainBox);
		recordPanel.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		deletePanel.setLayout(new FlowLayout(FlowLayout.RIGHT));
		deletePanel.add(deleteButton);
		deletePanel.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		deletePanel.setPreferredSize(new Dimension(300,40));
		deleteButton.setBackground(null);
		deleteButton.setBorder(null);
		deleteButton.setContentAreaFilled(false);
		deleteButton.addActionListener(new deleteListener());
		scroll.setBorder(null);
		scroll.getVerticalScrollBar().setPreferredSize(new Dimension(8,0));
		scroll.getVerticalScrollBar().setUnitIncrement(10);
		this.add(scroll,BorderLayout.CENTER);
		this.add(deletePanel,BorderLayout.SOUTH);
	}
	public void addButton(String formula,String result) {
		mainBox.remove(label);
		JButton button=new JButton();
		button.setBorder(null);
		button.addActionListener(listener);
		button.setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		button.setHorizontalAlignment(SwingConstants.RIGHT);
		button.setPreferredSize(new Dimension(350,formula.length()/30*20+50));
		formula=formula.replace(" ", "\t").replace("(", "( ").replace(")", " )");
		button.setText("<html><p style=\"text-align:left;\">"+formula+"<br><font size=6>"+result+"</font></p></html>");
		button.addMouseListener(new buttonFocusAdapter());
		mainBox.add(button,0);
		this.repaint();
		this.revalidate();
	}
	private class buttonFocusAdapter extends MouseAdapter{
		public void mouseEntered(MouseEvent e) {
			e.getComponent().setBackground(Color.LIGHT_GRAY);
		}
		public void mouseExited(MouseEvent e) {
			e.getComponent().setBackground(new Color(Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB,Constant.BACKGROUND_RGB));
		}
	}
	public void setListener(ActionListener listener) {
		this.listener=listener;
	}
	public class deleteListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			mainBox.removeAll();
			mainBox.add(label);
			mainBox.repaint();
			mainBox.revalidate();
		}
	}
}
