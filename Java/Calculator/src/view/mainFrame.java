package view;
import java.awt.*;
import javax.swing.*;
import javax.swing.event.*;
public class mainFrame extends JFrame {
	private buttonPanel buttons=new buttonPanel();
	private Container container=getContentPane();
	private labelPanel calculatings=new labelPanel();
	private menuPanel log=new menuPanel();
	private GridBagLayout gridBag=new GridBagLayout();
	private GridBagConstraints constraints=new GridBagConstraints();
	public void loadFrame() {
		setTitle("계산기");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		container.setLayout(new BorderLayout());
		constraints.weightx=1.0;
		constraints.weighty=1.0;
		constraints.fill=GridBagConstraints.BOTH;
		constraints.gridheight = 1;
		addGridBag(calculatings,0,0);
		constraints.gridheight = 2;
		addGridBag(buttons,0,1);
		//centerPanel.add(buttons,BorderLayout.CENTER);
		//centerPanel.add(calculatings,BorderLayout.NORTH);
		//northPanel.setPreferredSize(new Dimension(400,200));
		//buttons.setPreferredSize(new Dimension(400,400));
		JPanel centerPanel=new JPanel(gridBag);
		container.add(log,BorderLayout.NORTH);
		container.add(centerPanel,BorderLayout.CENTER);
		setSize(400, 600);
		setVisible(true);
	}
	
	private void addGridBag(Component component,int x,int y) {
		constraints.gridx=x;
		constraints.gridx=y;
		gridBag.setConstraints(component, constraints);
	}
	
}
