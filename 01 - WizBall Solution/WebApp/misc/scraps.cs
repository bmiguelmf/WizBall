<asp:CheckBox Text="<%# DataBinder.Eval(Container.DataItem, "Name") %>" value="<%# DataBinder.Eval(Container.DataItem, "ID") %>" ID="Comp<%# DataBinder.Eval(Container.DataItem, "ID") %>" runat="server" />
<input type="checkbox" id="Comp<%# DataBinder.Eval(Container.DataItem, "ID") %>"  name="<%# DataBinder.Eval(Container.DataItem, "ID") %>" value="<%# DataBinder.Eval(Container.DataItem, "Name") %>" />



                                    <asp:CheckBox Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' ID='CheckBox1' runat="server"/>

                                    
                                                <asp:CheckBox value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' ClientIDMode="Static" ID='CheckBox1' runat="server" />

                                                <input type="checkbox" name="var_id[]" id="<%# DataBinder.Eval(Container.DataItem, "ID") %>" value="<%# DataBinder.Eval(Container.DataItem, "ID") %>">

                                                <asp:CheckBox Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>' value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' ID='ckBtn' runat="server" />