Vue.component('input-text', {
    props: {
        title: String,
        id: String,
        class: String,
        value: String,
        style: String,
        require: Boolean
    },
    template: '<input type="text" v-bind:id="id" v-bind:class="class" v-bind:style="style" v-bind:value="value"/>',
    data: function () {
        return {
            inputValue: this.value
        };
    },
    methods: {
        getValue: function () {

            return this.inputValue;
        }
    }
})