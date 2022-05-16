package view;
import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import java.awt.event.KeyAdapter;

import javax.swing.*;
import javax.swing.event.*;
public class CalculatorFrame extends JFrame {
	public ButtonPanel buttons=new ButtonPanel();
	private Container container=getContentPane();
	public TextPanel calculatings=new TextPanel();
	public MenuPanel log=new MenuPanel();
	private GridBagLayout gridBag=new GridBagLayout();
	private GridBagConstraints[] constraints=new GridBagConstraints[2];
	private JPanel centerPanel=new JPanel(gridBag);
	public LogPanel panel=new LogPanel();
	private JScrollPane scroll=new JScrollPane(panel,ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS,ScrollPaneConstants.HORIZONTAL_SCROLLBAR_NEVER);
	public void loadFrame() {
		setTitle("계산기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		container.setLayout(new BorderLayout());
		container.add(log,BorderLayout.NORTH);
		container.add(centerPanel,BorderLayout.CENTER);
		constraints[0]=new GridBagConstraints();
		constraints[1]=new GridBagConstraints();
		addGridBag(calculatings, constraints[0], 0, 0, 1, 1);
		addGridBag(buttons, constraints[1], 1, 0, 1, 2);
		setPreferredSize(new Dimension(450,600));
		setMinimumSize(getPreferredSize());
		this.addComponentListener(new ResizeListener());
		this.setIconImage(new ImageIcon("image/calculator.png").getImage());
		setVisible(true);
	}
	public void setLogFrame() {
		centerPanel.removeAll();
		addGridBag(calculatings, constraints[0], 0, 0, 1, 1);
		addGridBag(scroll, constraints[1], 1, 0, 1, 2);
		log.convertToLogColor();
		calculatings.convertToLogColor();
		container.repaint();
		container.revalidate();
	}
	public void setCalculatorFrame() {
		centerPanel.removeAll();
		addGridBag(calculatings, constraints[0], 0, 0, 1, 1);
		addGridBag(buttons, constraints[1], 1, 0, 1, 2);
		log.convertToCalculatorColor();
		calculatings.convertToCalculatorColor();
		container.repaint();
		container.revalidate();
	}
	private void addGridBag(Component component,GridBagConstraints constraint,int x,int y,int weigthx,int weigthy) {
		constraint.gridx=x;
		constraint.gridx=y;
		constraint.weightx=weigthx;
		constraint.weighty=weigthy;
		constraint.fill=GridBagConstraints.BOTH;
		centerPanel.add(component,constraint);
	}
	public void refresh() {
		setVisible(false);
		setVisible(true);
	}
	public void addKeyAdapter(KeyAdapter adapter) {
		buttons.setFocusable(true);
		buttons.requestFocusInWindow();
		buttons.addKeyListener(adapter);
	}
	public class ResizeListener extends ComponentAdapter {
        public void componentResized(ComponentEvent e) {
            if(getSize().width>500) {
            	System.out.print(getSize().width);
            	setCalculatorFrame();
            	container.add(panel,BorderLayout.EAST);
            	container.repaint();
            	container.revalidate();
            }
            else {
            	container.remove(panel);
            	container.repaint();
            	container.revalidate();
            }
        }
	}
}
