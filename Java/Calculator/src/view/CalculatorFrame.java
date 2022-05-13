package view;
import java.awt.*;
import javax.swing.*;
import javax.swing.event.*;
public class CalculatorFrame extends JFrame {
	public ButtonPanel buttons=new ButtonPanel();
	private Container container=getContentPane();
	public TextPanel calculatings=new TextPanel();
	private MenuPanel log=new MenuPanel();
	private GridBagLayout gridBag=new GridBagLayout();
	private GridBagConstraints[] constraints=new GridBagConstraints[2];
	private JPanel centerPanel=new JPanel(gridBag);
	public void loadFrame() {
		setTitle("계산기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		container.setLayout(new BorderLayout());
		constraints[0]=new GridBagConstraints();
		constraints[1]=new GridBagConstraints();
		addGridBag(calculatings, constraints[0], 0, 0, 1, 1);
		addGridBag(buttons, constraints[1], 1, 0, 1, 2);
		container.add(log,BorderLayout.NORTH);
		container.add(centerPanel,BorderLayout.CENTER);
		setSize(400, 600);
		this.setIconImage(null);
		setVisible(true);
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
}
